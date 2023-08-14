using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;
    
    public GameObject player;
    
    public float health;
    public float maxHealth;

    void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyonLoad(this);
    }
    
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
            Destroy(player);
        }
    }


}
