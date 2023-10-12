using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //speed and jumpforce are controlled by the sidebar >>>>>
    public float MoveSpeed;
    public float JumpForce;
    private Rigidbody2D rb;
    private bool Grounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // used for the jump. since we arent using transform for jumping
    }

    // how basic dummy. mass = 10, gravity = 4, jumpforce = 200, speed like 6  or so
    // fixedupdate makes it so fps doesnt fuck up the game. prblem is is that it missed some frames on jumps
    //so until we find a good way to fix this we will keep it as update
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * MoveSpeed) * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * MoveSpeed) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            //transform.position.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
    void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = false;
        }

    }
}
