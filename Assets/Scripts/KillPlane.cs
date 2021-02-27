using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemy = GetComponent<EnemyHealth>();

            Destroy(other.gameObject);


        }
        else if (other.tag == "Player")
        {
            PlayerHealth player = GetComponent<PlayerHealth>();
            Destroy(other.gameObject);

            GameOver.instance.PlayerDeath();
        }
        else if (other.tag == "Barrel" || other.tag == "Potion")
            Destroy(other.gameObject);
    }
}
