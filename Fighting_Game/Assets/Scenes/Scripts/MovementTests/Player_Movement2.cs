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
    public Sprite Crouch;
    public Sprite Standing;
    public Animator Anime;
    public bool BlockRight = false;
    public bool BlockLeft = false;
    public float Crouchspeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }
            else if (Input.GetKey(player2Controls.Left) && !BlockLeft)
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

        if (Input.GetKey(player2Controls.Down))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Crouch;
            Anime.SetBool("Crouch", true);
            Anime.SetBool("Idle", false);
            MoveSpeed = 4;
        }
        if (Input.GetKeyUp(player2Controls.Down))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Standing;
            Anime.SetBool("Crouch", false);
            Anime.SetBool("Idle", true);
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
