using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    float randomValue;
    public bool isRight;
    bool isReady;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            randomValue = Random.Range(1, 3);

            if (randomValue != 3)
            {
                if (isRight)
                {
                        other.attachedRigidbody.velocity = new Vector2(-5, Random.Range(6,8));
                }
                else
                {
                        other.attachedRigidbody.velocity = new Vector2(5, Random.Range(6, 8));
                    
                }
                    
            }
        }
    }

    
}
