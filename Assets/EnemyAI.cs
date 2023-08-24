using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{ 
    public float movementSpeed;   // Speed at which the enemy moves
    public float attackRange;     // Range at which the enemy attacks the player
    public float lookRadios;
    private bool isAttacking = false;

    private TestEnemyShooting shootAttack;
    private Transform player;
    
    private void Start()
    {
        player = PlayerStats.playerStats.player.transform;
        shootAttack = GetComponent<TestEnemyShooting>();
    }

    private void Update()
    {
            if (player == null)
                return;

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            // Start the attack coroutine
            
            shootAttack.StartCoroutine("ShootPlayer");
            isAttacking = true;
        }
        else if (distanceToPlayer > attackRange && isAttacking)
        {
            // Stop the attack coroutine
            shootAttack.StopCoroutine("ShootPlayer");
            isAttacking = false;
        }
        else if (distanceToPlayer <= lookRadios && distanceToPlayer > attackRange)
        {
            FollowPlayer();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadios);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void FollowPlayer()
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.Translate(direction * movementSpeed * Time.deltaTime);
    }
}

