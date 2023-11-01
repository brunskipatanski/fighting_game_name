using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //speed and jumpforce are controlled by the sidebar >>>>>
    /*Doublejump force is for double jump. it's its own var for easy coding with airadash. movingleft-right are used for jumping and maybe blocking in the future. you can name 
     other stuff like MoveRight or MoveLeft for example controls. grounded var is used for reading if players are hitting the ground it usus the ground tag so be sure to set that shit up.
     Allowmove enables or disables the ability to move your char, for jumping and knockdown. is moving is for other general stuff like neutral jump.
    DoubleJumpForce is for neutral doublejumps, DoubleMoveForce is for Left and right ones. i also changed to jump code a bit*/
    public float MoveSpeed;
    public float JumpForce;
    public float DoubleJumpForce;
    public float AirDash;
    public bool MovingLeft;
    public bool MovingRight;
    public float MoveForce;
    public float DoubleMoveForce;
    public bool DoubleJumped = false;
    public bool AirDashed = false;
    private Rigidbody2D rb;
    private bool Grounded = false;
    public bool AllowMove = true;
    public bool IsMoving = false;
    public Sprite Crouch;
    public Sprite Standing;
    private SpriteRenderer spriteRenderer;
    public Animator Anime;
    public bool BlockRight = false;
    public bool BlockLeft = false;

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
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
            else if (Input.GetKey(KeyCode.D) && !BlockRight)
            {
                transform.position = (Vector2) transform.position + (Vector2.right * MoveSpeed) * Time.deltaTime;
                MovingRight = true;
                MovingLeft = false;
                IsMoving = true;
                //Debug.Log("Player Moving right");
            }
            else if (Input.GetKey(KeyCode.A) && !BlockLeft)
            {
                transform.position = (Vector2) transform.position + (Vector2.left * MoveSpeed) * Time.deltaTime;
                MovingLeft = true;
                MovingRight = false;
                IsMoving = true;
                //Debug.Log("Player Moving left");
            }
            else
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Grounded == true)
            {
                rb.velocity = Vector2.zero;  // < these lines are for removing any other forces. in this case the jumps horizontal force
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                AllowMove = false; // Main line for making it so you can't move in the air

                if (MovingLeft == true)
                {
                    rb.AddForce(Vector2.left * MoveForce, ForceMode2D.Impulse);
                }
                else if (MovingRight == true)
                {
                    rb.AddForce(Vector2.right * MoveForce, ForceMode2D.Impulse);
                }
            }
            else if (DoubleJumped == false)
            {
                rb.velocity = Vector2.zero;  
                rb.AddForce(Vector2.up * DoubleJumpForce, ForceMode2D.Impulse);
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(Vector2.left * DoubleMoveForce, ForceMode2D.Impulse);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(Vector2.right * DoubleMoveForce, ForceMode2D.Impulse);
                }
                AllowMove = false;
                DoubleJumped = true;
                Debug.Log("DoubleJumped");
            }
        }

        if (Input.GetKey("s"))
        {
            // could try GetKeyDown like on the other control, theres a difference might fix bugs
            gameObject.GetComponent<SpriteRenderer>().sprite = Crouch;
            Anime.SetBool("Crouch", true);
            Anime.SetBool("Idle", false);
        }
        if (Input.GetKeyUp("s"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Standing;
            Anime.SetBool("Idle", true);
            Anime.SetBool("Crouch", false);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
            DoubleJumped = false;
        }
        if (Grounded == true)
        {
            AllowMove = true;

            //check if player is grounded. remember to place those tags
            //also sets the grounded var and allowmove for the stuff they are for
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal == Vector2.left)
                {
                    // Collision occurred from the right side.

                    BlockRight = true;
                    Debug.Log("Collision from the Right!");
                }
                if (contact.normal == Vector2.right) {
                    BlockLeft = true;
                    Debug.Log("Collision from the Left!");
                }
            }

        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            BlockRight = false;
            BlockLeft = false;
            // unbocks the movement right and left
        }
        //^^ is this code for blocking like attacks? or some bug fix?
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = false;
            // above code of this one checks if player is touching object tagged "ground" this one check the smae but for Exit so when you stop touching.
        }

    }
}
