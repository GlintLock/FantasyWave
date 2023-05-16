using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image playerHealthImage;
    public PlayerController player;
    public float healthPoints, maxHealthPoints = 100;
    public float damagePoints = 10;
    public GameManager GameManager;
    public Sprite healthFrame;
    
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
    }
    // Update is called once per frame
    void Update()
    {
        playerHealthImage.fillAmount = Mathf.Clamp(healthPoints / maxHealthPoints, 0, 1f);
    }
    
    void OnPlayerHit()
    {
        healthPoints -= damagePoints;
        if (healthPoints == 0)
        {
            Destroy(gameObject, 0.01f);            
            GameManager.GameOver();
        }
    }
}
