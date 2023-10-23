using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public Sprite[] standing;
    public Sprite[] crouching;
    private BoxCollider2D collider2D;
    private Transform skin;
    private SpriteRenderer characterRender;
    private SpriteRenderer skinRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        skin = transform.GetChild(0);
        characterRender = GetComponent<SpriteRenderer>();
        skinRenderer = skin.GetComponent<SpriteRenderer>();
    }

    public void Crouch2(bool pressed)
    {
        if (pressed)
        {
            collider2D.size = new Vector2(collider2D.size.x, 4.5f);
            collider2D.offset = new Vector2(collider2D.offset.x, -0.5f);
            characterRender.sprite = crouching[0];
            skinRenderer.sprite = crouching[1];
        }
        else
        {
            collider2D.size = new Vector2(collider2D.size.x, 6f);
            collider2D.offset = new Vector2(collider2D.offset.x, 0);
            characterRender.sprite = standing[0];
            skinRenderer.sprite = standing[1];
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouch2(!crouching);
        }
    }
}
