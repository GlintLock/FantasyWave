using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize(); // make diagonal movement the same speed as horizontal/vertical

        rb.velocity = movement * speed;
    }
}
