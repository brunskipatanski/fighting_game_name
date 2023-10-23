using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //speed and jumpforce are controlled by the sidebar >>>>>
    /* ill add the details later :D */
    public float MoveSpeed;
    public float JumpForce;
    public float DoubleJumpForce;
    public float AirDash;
    public bool MovingLeft;
    public bool MovingRight;
    public float MoveForce;
    public bool DoubleJumped = false;
    public bool AirDashed = false;
    private Rigidbody2D rb;
    private bool Grounded = false;
    public bool AllowMove = true;
    public bool IsMoving = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // used for the jump. since we arent using transform for jumping
    }

    // how basic dummy. mass = 10, gravity = 4, jumpforce = 175, speed like 6  or so we can change these
    // fixedupdate makes it so fps doesnt fuck up the game. prblem is is that it missed some frames on jumps
    //so until we find a good way to fix this we will keep it as update
    //collision detection should be continuous
    void Update()
    {
        if (AllowMove)//check for movement
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + (Vector3.right * MoveSpeed) * Time.deltaTime;
                MovingRight = true;
                MovingLeft = false;
                IsMoving = true;
                Debug.Log("Player Moving right");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + (Vector3.left * MoveSpeed) * Time.deltaTime;
                MovingLeft = true;
                MovingRight = false;
                IsMoving = true;
                Debug.Log("Player Moving left");
            }
            else
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
        {
            //transform.position.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            AllowMove = false; //main line for making it so you cant move in-air
            if (MovingLeft == true)
            {
                rb.AddForce(Vector2.left * MoveForce, ForceMode2D.Impulse);
            }

            else if (MovingRight == true)
            {
                rb.AddForce(Vector2.right * MoveForce, ForceMode2D.Impulse);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
        if (Grounded == true)
        {
            AllowMove = true;
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
