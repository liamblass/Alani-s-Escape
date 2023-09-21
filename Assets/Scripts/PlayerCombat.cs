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
    public GameObject projectile;
    public float projectileForce;
    public float projectileRate;
    private float nextProjectileRate;


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
    private void ShootProjectile()
    {
        if (Time.time > projectileRate)
        {
            nextProjectileRate = Time.time + projectileRate;
            if (isAttacking)
            {
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity.normalized);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = transform.position;
                Vector2 direction = (mousePos - myPos).normalized;
                spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                float damage = PlayerStats.playerStats.GetRandomDamage();
                spell.GetComponent<TestPorjectiles>().damage = damage;
            }
        }
    }

    private void Attack()
    {
        
        if (Time.time > nextAttackTime)
        {
            nextAttackTime = attackRate + Time.time;
            if (isAttacking)
            {
                animator.SetTrigger("Attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                attackDamege = PlayerStats.playerStats.GetRandomDamage();

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyDamage>().DealDamage(attackDamege);
                    Debug.Log("Player damage: " + attackDamege);
                }
                if (transform.position.x > mousePos.x)
                {
                    spriteRenderer.flipX = true;
                    //attackPoint.transform.Translate(attackPoint.position.x * -1, attackPoint.position.y, attackPoint.position.z);
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x >= transform.position.x)
            {
                spriteRenderer.flipX = false;
                attackPoint.localPosition = new Vector3(1, 0, 0f);
            }
            if (mousePos.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
                attackPoint.localPosition = new Vector3(-1, 0, 0f);

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ShootProjectile();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x >= transform.position.x)
            {
                spriteRenderer.flipX = false; 
            }
            if (mousePos.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
