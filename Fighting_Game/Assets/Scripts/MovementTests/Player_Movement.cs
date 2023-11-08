using UnityEngine;
using UnityEngine.U2D;

public class Player_Movement : MonoBehaviour
{
    // isinBlocking = if a player is blocking another players attack /is in blockstun
    // IsAttacking = if player is the middle of attacking
    //chat deleted most of the comments for no reason

    // public Dummy_2_5A dummy2_5A;
    public Player_Controls player1Controls; // Reference to PlayerControl1


    public bool IsinBlocking = false;
    public bool IsAttacking = false;
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
    public Animator Anime;
    public bool BlockRight = false;
    public bool BlockLeft = false;
    public float Crouchspeed;
    public bool IsCrouching = false;
    private SpriteRenderer sprite2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        sprite2 = GetComponent<SpriteRenderer>();
    }
    // ^^ for jumps and stuff
    void Update()
    {
        //A attack code. still needs check for when actively hitting the opponent for a cancel window
        //remember ! stands for not!
        if (Input.GetKeyDown(player1Controls.A_Attack) && !IsAttacking && !IsinBlocking)
        {
            Debug.Log("player 1, Did an A attack!");
        }
        //allowmove makes it so you can use wasd and shit to move
        if (AllowMove)
        {
            if (Input.GetKey(player1Controls.Right) && Input.GetKey(player1Controls.Left))
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
            else if (Input.GetKey(player1Controls.Right) && !BlockRight)
            {
                transform.position = (Vector2)transform.position + (Vector2.right * MoveSpeed) * Time.deltaTime;
                MovingRight = true;
                MovingLeft = false;
                IsMoving = true;
                Anime.SetBool("Walking2", true);
            }
            else if (Input.GetKey(player1Controls.Right) && !BlockRight)
            {
                Anime.SetBool("Walking2", false);
            }

            else if (Input.GetKey(player1Controls.Left) && !BlockLeft)
            {
                transform.position = (Vector2)transform.position + (Vector2.left * MoveSpeed) * Time.deltaTime;
                MovingLeft = true;
                MovingRight = false;
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
        }

        if (Input.GetKeyDown(player1Controls.Jump))
        {
            if (Grounded == true)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                AllowMove = false;

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
                if (Input.GetKey(player1Controls.Left))
                {
                    rb.AddForce(Vector2.left * DoubleMoveForce, ForceMode2D.Impulse);
                }
                else if (Input.GetKey(player1Controls.Right))
                {
                    rb.AddForce(Vector2.right * DoubleMoveForce, ForceMode2D.Impulse);
                }
                AllowMove = false;
                DoubleJumped = true;
            }
        }
        // added some check for crouching for stuff like low block and low attacks
        if (Input.GetKey(player1Controls.Down))
        {
            Anime.SetBool("Crouch2", true);
            IsCrouching = true;
            MoveSpeed = 4;
        }
        if (Input.GetKeyUp(player1Controls.Down))
        {
            Anime.SetBool("Crouch2", false);
            IsCrouching = false;
            MoveSpeed = 8;
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
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal == Vector2.left)
                {
                    BlockRight = true;
                }
                if (contact.normal == Vector2.right)
                {
                    BlockLeft = true;
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
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = false;
        }
    }
    }
