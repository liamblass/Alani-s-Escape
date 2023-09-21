using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;
    public float projectileForce;

    private void Update()
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        if (Input.GetMouseButtonDown(1))
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
