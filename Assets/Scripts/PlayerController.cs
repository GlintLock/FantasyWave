using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public enum PlayerStates {
        IDLE,

        WALK,

        ATTACK
    }
    PlayerStates CurrentState
    {
        set
        {
            if (p_stateLock == false)
            {
                p_currentState = value;

                switch (p_currentState)
                {
                    case PlayerStates.IDLE:
                        p_animator.Play("IDLE");
                        p_canMove = true;
                        break;
                    case PlayerStates.WALK:
                        p_animator.Play("WALK");
                        p_canMove = true;
                        break;
                    case PlayerStates.ATTACK:
                        p_animator.Play("ATTACK");
                        p_stateLock = true;
                        p_canMove = false;
                        break;
                }
            }
            
        }
    }
    public float speed = 5f;
    Vector2 p_moveInput = Vector2.zero;
    private Rigidbody2D rb;
    Animator p_animator;
    SpriteRenderer p_spriteRenderer;
    PlayerStates p_currentState;
    bool p_stateLock = false;
    bool p_canMove = true;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        p_animator = GetComponent<Animator>();
        p_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
  
    }

    void FixedUpdate()
    {
        rb.velocity = p_moveInput * speed;
    }

   void OnMove(InputValue value)
    {
        p_moveInput = value.Get<Vector2>();

        if(p_canMove && p_moveInput != Vector2.zero)
        {
            CurrentState = PlayerStates.WALK;
            p_animator.SetFloat("xMove", p_moveInput.x);
            p_animator.SetFloat("yMove", p_moveInput.y);

        } else
        {
            CurrentState = PlayerStates.IDLE;
        }
    }
    void OnFire()
    {
        CurrentState = PlayerStates.ATTACK;
    }
    void OnAttackEnd()
    {
        p_stateLock = false;
        CurrentState = PlayerStates.IDLE;
    }
    
}
