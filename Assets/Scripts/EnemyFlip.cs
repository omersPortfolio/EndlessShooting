using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{

    SpriteRenderer sr;
    GameObject player;
    SpriteRenderer weaponSr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player"); 
    }
    

    void Update()
    {
        if (player != null)
        {
            sr.flipX = player.transform.position.x < transform.position.x;
        }

        
    }

    
}
