using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionLV01 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Save current scene position and load the target scene
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.lastScenePosition = GetTargetSpawnPosition();
                SceneManager.LoadScene("Level 01");
            }
            else
            {
                Debug.LogError("PlayerMovement script not found on the player GameObject.");
            }
        }
    }

    public Vector2 GetTargetSpawnPosition()
    {
        GameObject toLevel02 = GameObject.Find("ToLevel02");

        if (toLevel02 != null)
        {
            return new Vector2(toLevel02.transform.position.x, toLevel02.transform.position.y + 1f);
        }
        else
        {
            Debug.LogWarning("ToLevel02 GameObject not found.");
            return Vector2.zero;
        }
    }
}
