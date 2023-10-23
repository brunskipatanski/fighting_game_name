using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followThreshold; // X position where the camera starts to follow

    private void Update()
    {
        // Check if the player's position is greater than the followThreshold
        if (player.position.x > followThreshold)
        {
            // Calculate the camera's new position to follow the player
            Vector2 newPosition = transform.position;
            newPosition.x = player.position.x;
            transform.position = newPosition;
        }
    }
}