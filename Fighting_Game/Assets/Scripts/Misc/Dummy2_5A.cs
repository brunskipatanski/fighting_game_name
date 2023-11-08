using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy2_5A : MonoBehaviour
{
    public const float HitBoxWidth5A = 5f;
    public const float HitBoxHeight5A = 5f;
    //^^ size of hitbox
    public GameObject fiveA_HitBoxObject;
    //^^ this is for the gameobject thats the hitbox
    public void Spawn()
    {
        //creates the hitbox for the move with a boxcollider
        BoxCollider HitBoxCollider = gameObject.AddComponent<BoxCollider>();
        HitBoxCollider.size = new Vector3(HitBoxWidth5A, HitBoxHeight5A);

        Vector3 playerposition = transform.position;
        Vector3 offset = new Vector3(0, 0, 1);
        fiveA_HitBoxObject.transform.position = playerposition + offset;

        Debug.Log("Hitbox hit!");
    }
}
