using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CharacterHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    private bool isDead;

    public GameManagerScript gameManager; 

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver(); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Barrel1" || collision.gameObject.name == "Barrel2" || collision.gameObject.name == "Barrel3" || collision.gameObject.name == "Crate1" || collision.gameObject.name == "Box1")
        {
            TakeDamage(25);
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth; 
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;  
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);  
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

}
