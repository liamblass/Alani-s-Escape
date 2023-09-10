using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;

    [Header("Player Settings")]
    public float health;
    public float maxHealth;

    public float mana;
    public float maxMana;

    public float minDamage;
    public float maxDamage;

    [Header("Player UI")]
    public TMP_Text healthText;
    public Slider healthSlider;
    
    public TMP_Text manaText;
    public Slider manaSlider;

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
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
        mana = maxMana;
        SetHealthUI();
    }


    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }


    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        healthText.text = Mathf.Ceil(health).ToString() + "/" + Mathf.Ceil(maxHealth).ToString();
        healthSlider.value = CalculateHealthPrecent();
    }

    private void SetManaUI()
    {
        manaText.text = Mathf.Ceil(mana).ToString() + "/" + Mathf.Ceil(maxMana).ToString();
        manaSlider.value = CalculateManaPrecent();
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
            health = 0;
            Destroy(player);
        }
    }

    private float CalculateManaPrecent()
    {
        return (mana / maxMana);
    }

    private float CalculateHealthPrecent()
    {
        return (health / maxHealth);
    }

    public float GetRandomDamage()
    {
        float damage = (Random.Range(minDamage, maxDamage));
        return damage;
    }
}
