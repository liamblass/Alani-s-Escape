using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionLV02 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with stairs!");

            // Save current scene position and load the target scene
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                Debug.Log("PlayerMovement script found on player GameObject.");

                playerMovement.lastScenePosition = GetTargetSpawnPosition();
                Debug.Log("Last scene position set: " + playerMovement.lastScenePosition);

                SceneManager.LoadScene("Level 02");
                Debug.Log("Loading Level 02.");
            }
            else
            {
                Debug.LogError("PlayerMovement script not found on the player GameObject.");
            }
        }
    }

    public Vector2 GetTargetSpawnPosition()
    {
        GameObject toLevel01 = GameObject.Find("ToLevel01");

        if (toLevel01 != null)
        {
            Debug.Log("ToLevel01 GameObject found.");
            return new Vector2(toLevel01.transform.position.x, toLevel01.transform.position.y - 1f);
        }
        else
        {
            Debug.LogWarning("ToLevel01 GameObject not found.");
            return Vector2.zero;
        }
    }
}

