using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy2_5A : MonoBehaviour
{
    // These comments describe the properties and methods of the Dummy2_5A class
    public int damage = 10; // Attack damage
    public string[] CancelInto = { "Dummy2_5B", "Dummy2_2B" }; // Moves this move can cancel into

    private const float HitBoxWidth = 1.0f;
    private const float HitBoxHeight = 1.0f; // Hitbox dimensions

    public void Execute()
    {
        // Create a hitbox using a BoxCollider
        BoxCollider HitBoxCollider = gameObject.AddComponent<BoxCollider>();
        HitBoxCollider.size = new Vector3(HitBoxWidth, HitBoxHeight);

        // Logic for performing the "dummy2_5A" basic punch attack
        // Determine if the attack hits the opponent by checking for collisions

        // If the attack hits the opponent, apply damage or other effects
        /*if (hitOpponent)
        {
            // Apply damage
        }
        */
        // Destroy the hitbox after the attack is resolved
        //Destroy(hitboxCollider);
    }

    public bool CanCancelInto(string NextMove)
    {
        // Check if the next move is in the list of allowed cancels
        return System.Array.Exists(CancelInto, move => move == NextMove);
    }
}
/*
if (playerInput.AttackButtonPressed)
{
    if (dummy2_5A.CanCancelInto(nextMove))
    {
        // Check if the attack hits the opponent (you'll need to implement this logic)
        if (HitOpponent())
        {
            dummy2_5A.Execute();
        }
    }
}

/*  Assuming you have a collision check function called HitOpponent
if (HitOpponent())
{
    dummy2_5A.Execute();
}
*/
