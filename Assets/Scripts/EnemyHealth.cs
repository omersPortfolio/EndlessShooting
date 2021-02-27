using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int _currentHealth;
    public int currentHealth
    {

        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    public Transform deathParticles;

    public static EnemyHealth instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;

    }

    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameManager.KillEnemy(this);
        }
    }

    
}
