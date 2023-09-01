using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float smoothing;
    public Vector3 offset;
    private Transform player;

    private void Start()
    {
        player = PlayerStats.playerStats.player.transform;
    }

    void FixedUpdate()
    {
        if (player != null)
        { 
            Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPosition;
        }
    }
}
