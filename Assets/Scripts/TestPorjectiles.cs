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
            if(collision.GetComponent<EnemyDamage>() != null)
            {
                collision.GetComponent<EnemyDamage>().DealDamage(damage);
            }
            Destroy(gameObject);
        }        
    }
}


