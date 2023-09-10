using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform attackPoint;

    public float attackRange;
    private float attackDamege;
    public float attackRate;
    private float nextAttackTime;
    private Vector2 mousePos;
    private Vector2 diraction;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;


    public LayerMask enemyLayers;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(PlayerAttack());
    }

    void Update()
    {
        checkInput();
    }

    private void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (isAttacking)
            {
                animator.SetTrigger("Attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                attackDamege = PlayerStats.playerStats.GetRandomDamage();

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyDamage>().DealDamage(attackDamege);
                }
                if (transform.position.x > mousePos.x)
                {
                    spriteRenderer.flipX = true;
                    attackPoint.transform.Translate(attackPoint.position.x * -1, attackPoint.position.y, attackPoint.position.z);
                    //attackPoint.position = new Vector3(mousePos.x / Screen.width - .5f, 0, mousePos.y / Screen.height - .5f);
                }

            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        //if (attackPoint = null)
        //    return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x >= transform.position.x)
            {
                spriteRenderer.flipX = false;
                attackPoint.localPosition = new Vector3(1, attackPoint.position.y, 0f);
            }
            if (mousePos.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
                attackPoint.localPosition = new Vector3(-1, attackPoint.position.y, 0f);

            }
        }
    }
}
