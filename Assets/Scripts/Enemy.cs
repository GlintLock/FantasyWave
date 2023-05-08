using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum SlimeStates
    {
        Slime_Attack,

        Slime_Move,

        Slime_Die,

        Slime_Idle,

        Slime_Hit
    }
    SlimeStates CurrentState
    {
        set
        {
            if (s_stateLock == false)
            {
                s_currentState = value;

                switch (s_currentState)
                {
                    case SlimeStates.Slime_Idle:
                        s_animator.Play("Slime_Idle");
                        s_canMove = true;
                        break;
                    case SlimeStates.Slime_Move:
                        s_animator.Play("Slime_Move");
                        s_canMove = true;
                        break;
                    case SlimeStates.Slime_Hit:
                        s_animator.Play("Slime_Hit");
                        s_canMove = true;
                        break;
                    case SlimeStates.Slime_Die:
                        s_animator.Play("Slime_Die");
                        s_canMove = true;
                        break;
                    case SlimeStates.Slime_Attack:
                        s_animator.Play("Slime_Attack");
                        s_stateLock = true;
                        s_canMove = false;
                        break;
                }
            }

        }
    }
    bool s_stateLock = false;
    bool s_canMove = true;
    Animator s_animator;
    SpriteRenderer s_spriteRenderer;
    SlimeStates s_currentState;
    [SerializeField] float health, maxHealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDmg(float dmgAmount)
    {
        health -= dmgAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
