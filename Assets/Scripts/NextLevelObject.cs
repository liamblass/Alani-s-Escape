using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            if (collision.tag == "Player")
            {
                LevelManager.levelManager.LoadNextScene();
            } 
        }
    }
}
