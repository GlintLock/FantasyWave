using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
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
    public void TakeDmg(float dmgAmount)
    {
        health -= dmgAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
