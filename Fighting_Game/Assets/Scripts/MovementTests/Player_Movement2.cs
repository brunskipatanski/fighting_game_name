using UnityEngine;

public class Player_Movement2 : MonoBehaviour
{
    public Player_Controls2 player2Controls; // Reference to PlayerControl2

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
    private SpriteRenderer sprite;
    public Animator Anime;
    public bool BlockRight = false;
    public bool BlockLeft = false;
    public float Crouchspeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (AllowMove)
        {
            if (Input.GetKey(player2Controls.Right) && Input.GetKey(player2Controls.Left))
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
            else if (Input.GetKey(player2Controls.Right) && !BlockRight)
            {
                transform.position = (Vector2)transform.position + (Vector2.right * MoveSpeed) * Time.deltaTime;
                MovingRight = true;
                MovingLeft = false;
                IsMoving = true;
                //For animations
                Anime.SetBool("Walking", true);

            }
            else if (Input.GetKeyUp(player2Controls.Right) && !BlockRight)//This is for animaton so it stop when the right key is not pressed.
            {
                Anime.SetBool("Walking", false);
            }
            else if (Input.GetKey(player2Controls.Left) && !BlockLeft)
            {
                transform.position = (Vector2)transform.position + (Vector2.left * MoveSpeed) * Time.deltaTime;
                MovingLeft = true;
                MovingRight = false;
                IsMoving = true;
                //For animations
                Anime.SetBool("Walking", true);
                sprite.flipX = true;
            }
            else if (Input.GetKeyUp(player2Controls.Left) && !BlockLeft)//This is for animation so it stop when the button is not pressed and the flip is for when the button is not pressed it flips the sprite back to the right side.
            {
                Anime.SetBool("Walking", false);
                sprite.flipX = false;
            }
            else
            {
                IsMoving = false;
                MovingLeft = false;
                MovingRight = false;
            }
        }

        if (Input.GetKeyDown(player2Controls.Jump))
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
                if (Input.GetKey(player2Controls.Left))
                {
                    rb.AddForce(Vector2.left * DoubleMoveForce, ForceMode2D.Impulse);
                }
                else if (Input.GetKey(player2Controls.Right))
                {
                    rb.AddForce(Vector2.right * DoubleMoveForce, ForceMode2D.Impulse);
                }
                AllowMove = false;
                DoubleJumped = true;
            }
        }
        // remember to check if player is crouching when performing a jump, rn the chars can just crouch and then jump. like this aint mario bro
        if (Input.GetKey(player2Controls.Down))
        {

            Anime.SetBool("Crouch", true);
            MoveSpeed = 4;
        }
        if (Input.GetKeyUp(player2Controls.Down))
        {

            Anime.SetBool("Crouch", false);
            MoveSpeed = 8;
        }
        if (Input.GetKey(player2Controls.A_Attack))
        {
            Anime.SetBool("Punch", true);
        }
        if (Input.GetKeyUp(player2Controls.A_Attack))
        {
            Anime.SetBool("Punch", false);
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
