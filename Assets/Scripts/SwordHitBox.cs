using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public float dmg = 1f;
    public Collider2D swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        swordCollider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.SendMessage("OnHit", dmg);
    }
}
