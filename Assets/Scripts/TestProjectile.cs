using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "Player")
        {
            if(collision.GetComponent<EnemyReciveDamage>() != null)
            {
                collision.GetComponent<EnemyReciveDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }



}
