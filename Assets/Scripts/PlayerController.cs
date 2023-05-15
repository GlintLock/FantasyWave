using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //set the three states for the Player, and which animations play with each state
    public enum PlayerStates 
    {
        IDLE, WALK, ATTACK
    }
    PlayerStates PresentState
    {
        set
        {
            if (!isLocked)
            {
                liveState = value;

                switch (liveState)
                {
                    case PlayerStates.IDLE:
                        playerAnimator.Play("IDLE");                        
                        canMove = true;
                        break;
                    case PlayerStates.WALK:
                        playerAnimator.Play("WALK");                       
                        canMove = true;
                        break;
                    case PlayerStates.ATTACK:
                        playerAnimator.Play("ATTACK");
                        isLocked = true;
                        canMove = false;                                             
                        break;
                }
            }
            
        }
    }
    public GameObject swordHitBox;
    Collider2D bladeCollide;
    public float speed = 5f;
    Vector2 playerMoveInput = Vector2.zero;
    private Rigidbody2D rb;
    Animator playerAnimator;
    SpriteRenderer playerSpriteRenderer;
    PlayerStates liveState;
    bool isLocked = false;
    bool canMove = true;
   

    void Start()
    {
        //have p;ayer start at 0, 0 when the game starts
        transform.position = new Vector3(0, 0, 0);
        
            
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        bladeCollide = swordHitBox.GetComponent<Collider2D>();
    }

    void Update()
    {        

    }

    private void FixedUpdate()
    {
        //have the player move with the Input System directionals
        rb.velocity = playerMoveInput * speed;        
    }

    //set the direction the player faces when moving
   void OnMove(InputValue value)
    {
        playerMoveInput = value.Get<Vector2>();

        if(canMove && playerMoveInput != Vector2.zero)
        {
            PresentState = PlayerStates.WALK;
            playerAnimator.SetFloat("xMove", playerMoveInput.x);
            playerAnimator.SetFloat("yMove", playerMoveInput.y);

            
        } else
        {
            PresentState = PlayerStates.IDLE;
        }
    }
    
    //set attack animation when pressing the Fire button
    void OnFire()
    {
        PresentState = PlayerStates.ATTACK;        
    }

    //
    void OnAttackEnd()
    {
        isLocked = false;
        canMove = true;
        PresentState = PlayerStates.IDLE;
    }
    
    

}
