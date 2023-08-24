using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float attackRange;
    public float followRange;

    [Header("Damage")]
    public float minDamage;
    public float maxDamage;

    [Header("Projectiles")]
    public float projectileForce;
    public float projectileCooldown;
    public GameObject projectile;

    private Transform player;
    private bool isAttacking;

    private void Start()
    {
        player = PlayerStats.playerStats.player.transform;
        StartCoroutine(ShootPlayer());
    }

    public IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(projectileCooldown);
        if (player != null && isAttacking)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
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
            isAttacking = true;
        }
        else if (distanceToPlayer > attackRange && isAttacking)
        {
            // Stop the attack coroutine
            
            isAttacking = false;
        }
        else if (distanceToPlayer <= followRange && distanceToPlayer > attackRange)
        {
            FollowPlayer();
        }
    }

   
    private void FollowPlayer()
    {
        // Calculate the direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

 private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
