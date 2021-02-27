using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Rigidbody2D playerRb;

    SpriteRenderer sr;

    bool facingRight;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (playerRb.velocity.x < 0f)
        {
            sr.flipX = true;
            
        }
        else if (playerRb.velocity.x > 0f)
        {
            sr.flipX = false;
        }
    }
}
