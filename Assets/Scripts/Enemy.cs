using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Set the health of the slime and what anim ations play when that value goes below max health
    Rigidbody2D slime_rb;
    bool Alive = true;
    public float Life
    {
        set
        {
            if(value < healthPoints)
            {
                animator.SetTrigger("hit");
            }
            healthPoints = value;
            if (healthPoints <= 0)
            {
                animator.SetBool("Alive", false);
                GetComponent<FollowPlayer>().enabled = false;
                Destroy(gameObject, 0.5f);
                
            }
        }
        get
        {
            return healthPoints;
        }
    }
    public float healthPoints = 3;
    Animator animator;
    public float attackRadius = 0.05f;
    private float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {   //set the animator component and make sure the "Alive" boolean is set when starting the game     
        animator = GetComponent<Animator>();
        animator.SetBool("Alive", Alive);
        slime_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SlimeAttack();
    }
    //Deal damage to the slime when the player hits it
    void OnHit(float damage)
    {
        Life -= damage;
    }
    void SlimeAttack()
    {
        if (distanceToPlayer <= attackRadius)
        {
            animator.SetBool("target", true);            
        } else
        {
            animator.SetBool("target", false);
        }
        
    }
}
