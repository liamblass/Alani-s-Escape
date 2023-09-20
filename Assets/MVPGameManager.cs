using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MVPGameManager : MonoBehaviour
{
    public GameObject boss;
    public TMP_Text gameoverText;
    private GameObject player;


    private void Start()
    {
        player = PlayerStats.playerStats.player;
    }

    private void Update()
    {
        Die();
        KillBoss();
    }

    private void Die()
    {
        if (player == null)
        {
            gameoverText.text = "GameOver";
            Invoke(nameof(LoadLastScene), 3);
        }
    }

    private void KillBoss()
    {
        if (boss = null)
        {
            gameoverText.text = "Esscape!";
            Invoke(nameof(LoadLastScene), 5);
        }
    }

    public void LoadLastScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        scene--;
        SceneManager.LoadScene(scene);
    }
}
