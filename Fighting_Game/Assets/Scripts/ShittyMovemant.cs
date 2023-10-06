using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool onAir = false;

    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Apply horizontal movement force
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && !onAir)
        {
            // Apply vertical jump force
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onAir = false;
        }
    }
}