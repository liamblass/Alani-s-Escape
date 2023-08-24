using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPorjectiles : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.name != "Alani")
        {
            if(collision.GetComponent<EnemyRecieveDamage>() != null)
            {
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
        }        
    }
}


