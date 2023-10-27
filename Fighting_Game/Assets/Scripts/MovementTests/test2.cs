using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 6.0f;

    public bool blockLeft = false;
    public bool blockRight = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !blockLeft)
        {
            transform.position = (Vector2) transform.position + (Vector2.left * moveSpeed) * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && !blockRight)
        {
            transform.position = (Vector2) transform.position + (Vector2.right * moveSpeed) * Time.fixedDeltaTime;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal == Vector2.left)
                {
                    // Collision occurred from the right side.

                    blockRight = true;
                    Debug.Log("Collision from the Right!");
                }
                if (contact.normal == Vector2.right)
                {
                    blockLeft = true;
                    Debug.Log("Collision from the Left!");
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // unbocks the movement right and left
            blockRight = false;
            blockLeft = false;

        }
    }

}
