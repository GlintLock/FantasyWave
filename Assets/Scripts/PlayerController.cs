using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Vector2 m_moveInput = Vector2.zero;
    private Rigidbody2D rb;
    Animator m_animator;
    SpriteRenderer m_spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.velocity = m_moveInput * speed;
    }

    private void OnMove(InputValue value)
    {
        m_moveInput = value.Get<Vector2>();

        if(m_moveInput != Vector2.zero)
        {
            m_animator.SetFloat("xMove", m_moveInput.x);
            m_animator.SetFloat("yMove", m_moveInput.y);
        }
    }
    
}
