using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecieveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Start()
    {
        health = maxHealth;
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }


    public void HealCharacter(float heal)
    {
        heal += heal;
        CheckOverheal();
    }


    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }


    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
