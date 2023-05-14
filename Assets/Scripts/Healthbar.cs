using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Text healthPointText;
    public Image healthBar;
    float health, maxhealth = 100;
    public Image[] healthPoints;
    float fillSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthPointText.text = "Health: " + health + "%";
        if (health > maxhealth) health = maxhealth;

        fillSpeed = 3f * Time.deltaTime;
    }
    void HealthFill()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxhealth), fillSpeed;
    }
    bool DisplayHealthPoint(float health, int pointNumber)
    {
        return ((pointNumber * 10) >= health);
    }
    public void Heal(float healingpoints)
    {
        if (health < maxhealth)
            health += healingpoints;
    }
}
