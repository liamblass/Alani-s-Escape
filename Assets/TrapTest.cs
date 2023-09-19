using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTest : MonoBehaviour
{
    public float trapDamage;
    public float trapCooldown;
    private float nextTimeToDamage;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        nextTimeToDamage = Time.time + nextTimeToDamage;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time > nextTimeToDamage) 
        { 
            if (collision.name == "Alani")
            {
                PlayerStats.playerStats.DealDamage(trapDamage);
                spriteRenderer.color = Color.red;
            }
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyDamage>().DealDamage(trapDamage);
            }
        } 
        else
        {
            spriteRenderer.color = Color.blue;
        }
    }
}
