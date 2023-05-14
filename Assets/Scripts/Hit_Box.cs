using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Box : MonoBehaviour
{
    public float damage = 1f;
    public Collider2D swordCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        swordCollider.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        collider.collider.SendMessage("OnHit", damage);
    }
  
}
