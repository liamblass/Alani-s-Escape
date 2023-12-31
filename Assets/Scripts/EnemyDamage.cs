using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;
    public GameObject lootDrop;

    private Animator animator;

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }


    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPrecent();
        health -= damage;
        CheckDeath();
    }


    public void HealCharacter(float heal)
    {
        heal += heal;
        CheckOverheal();
        healthBarSlider.value = CalculateHealthPrecent();

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
            animator.SetBool("isDead", true);
            Destroy(gameObject, 0.5f);
            if (lootDrop != null)
            { 
                Instantiate(lootDrop, transform.position, Quaternion.identity);
            }
        }
    }

    private float CalculateHealthPrecent()
    {
        return (health / maxHealth);
    }
}
