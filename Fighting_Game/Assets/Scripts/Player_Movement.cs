using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //speed and jumpoforce are controlled by the sidebar >>>>>
    public float MoveSpeed;
    public float JumpForce;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * MoveSpeed) * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * MoveSpeed) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
