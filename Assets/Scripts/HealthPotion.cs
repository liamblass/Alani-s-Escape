using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float heal;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            if (collision.name == "Alani")
            {
                PlayerStats.playerStats.HealCharacter(heal);
                Destroy(gameObject);
            }
        }
    }
}

