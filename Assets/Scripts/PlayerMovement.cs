using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetPos;
    public float speed;
    public float dashRange;
    public float dashCooldown;
    private Vector2 direction;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float nextDashTime;
   

    private enum Facing { UP, DOWN, LEFT, RIGHT };
    private Facing facingDir = Facing.DOWN;

    // Store the last scene position
    public Vector2 lastScenePosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        Vector2 newPosition = (Vector2)transform.position + (direction * speed * Time.deltaTime);

        //Perform collision detection
        //RaycastHit2D hit = Physics2D.Linecast(transform.position, newPosition);

        //if (hit.collider == null)
        {
            // No collision detected, move the player
            transform.position = newPosition;
        }

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            facingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            facingDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            facingDir = Facing.RIGHT;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            facingDir = Facing.LEFT;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {            
            if (direction != Vector2.zero && Time.time >= nextDashTime) // Check if moving before dashing
            {
                nextDashTime = Time.time + dashCooldown;
                Debug.Log("this");
                Vector2 currentPos = transform.position;
                targetPos = Vector2.zero;
                if (facingDir == Facing.UP)
                {
                    targetPos.y = 1;
                }
                else if (facingDir == Facing.DOWN)
                {
                    targetPos.y = -1;
                }
                else if (facingDir == Facing.RIGHT)
                {
                    targetPos.x = 1;
                }
                else if (facingDir == Facing.LEFT)
                {
                    targetPos.x = -1;
                }
                transform.Translate(targetPos * dashRange);
            }
        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
    }
}


