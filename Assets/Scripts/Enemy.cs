using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    //Set the health of the slime and what anim ations play when that value goes below max health
    Rigidbody2D slime_rb;
    bool Alive = true;
    public float fewSeconds = 0.5f;
    public Collider2D slimeCollider;
    public float damagePoints = 10f;
    public float Life
    {
        set
        {
            if(value < slimeHealthPoints)
            {
                animator.SetTrigger("hit");
                
                
            }
            slimeHealthPoints = value;
            if (slimeHealthPoints <= 0)
            {
                animator.SetBool("Alive", false);
                GetComponent<FollowPlayer>().enabled = false;
                Destroy(gameObject, 0.5f);
                
            }
        }
        get
        {
            return slimeHealthPoints;
        }
    }
    public float slimeHealthPoints = 3;
    Animator animator;
    public float attackRadius = 0.05f;
    // Start is called before the first frame update
    void Start()
    {   //set the animator component and make sure the "Alive" boolean is set when starting the game     
        animator = GetComponent<Animator>();
        animator.SetBool("Alive", Alive);
        slime_rb = GetComponent<Rigidbody2D>();
        slimeCollider.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Deal damage to the slime when the player hits it
    void OnHit(float damage)
    {
        Life -= damage;
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        collider.collider.SendMessage("OnPlayerHit", damagePoints);
    }

}
