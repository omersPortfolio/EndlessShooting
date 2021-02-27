using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    public float _currentHealth;
    public float currentHealth
    {

        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    public bool isDead;

    [SerializeField]
    Image healthBar;

    public GameObject deathParticles;

    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth();
    }

    public void DamagePlayer(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();

        if (currentHealth <= 0)
        {
            isDead = true;
            currentHealth = 0;
            GameManager.KillPlayer(this);

            GameOver.instance.PlayerDeath();
            
        }

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }

    public void HealPlayer(int health)
    {
        currentHealth += health;
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
