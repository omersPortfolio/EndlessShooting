using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    PotionSpawner potionSpawner;

    private void Awake()
    {
        potionSpawner = FindObjectOfType<PotionSpawner>();
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            Destroy(gameObject);

            player.HealPlayer(50);
            player.UpdateHealth();
        }
        else if (other.tag == "Bullet" || other.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
