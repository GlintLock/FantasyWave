using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  
    public float moveSpeed = 0.25f; 
    public float followRadius = 0.25f; 
    private Transform player;
    private Rigidbody2D rb;
   
    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {    
       
        //have the enemy calculate the distance from them to the player
        //then seek them out when they are in range
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= followRadius)
        {            
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
            var slime = GetComponent<SpriteRenderer>();
            slime.flipX = (player.position.x < transform.position.x);
        }
        else
        {            
            rb.velocity = Vector2.zero;
        }
    }
    
}
