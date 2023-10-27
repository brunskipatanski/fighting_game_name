using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5.0f;
    [SerializeField] public float smoothness = 5.0f; // Adjust the smoothness of the movement

    private bool movingLeft = false;
    private bool movingRight = false;

    public bool blockLeft = false;
    public bool blockRight = false;

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !blockLeft)
        {
            movingLeft = true;
            movingRight = false;
        }
        else if (Input.GetKey(KeyCode.D) && !blockRight)
        {
            movingLeft = false;
            movingRight = true;
        }
        else
        {
            movingLeft = false;
            movingRight = false;
        }

        Vector2 targetPosition = transform.position;

        if (movingLeft)
        {
            targetPosition += Vector2.left * moveSpeed * Time.fixedDeltaTime;
        }
        else if (movingRight)
        {
            targetPosition += Vector2.right * moveSpeed * Time.fixedDeltaTime;
        }
        else if (blockLeft || blockRight)
        {
            Debug.Log("Shit is here");
            targetPosition = transform.position;
        }


        // Smoothly interpolate the position
        
        transform.position = Vector2.Lerp(transform.position, targetPosition, smoothness * Time.fixedDeltaTime);
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


