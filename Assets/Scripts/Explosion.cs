using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(DisableAndEnableController());
            PlayerHealth.instance.DamagePlayer(70);
        }


        else if (other.tag == "Enemy")
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            GameManager.KillEnemy(enemy);
        }    
        else if (other.tag == "Potion")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.enabled = true;
            
        }
    }

    IEnumerator DisableAndEnableController()
    {
        if (player != null)
        {
            player.enabled = false;
            yield return new WaitForSeconds(0.3f);
            player.enabled = true;
        }
        
    }
    
}
