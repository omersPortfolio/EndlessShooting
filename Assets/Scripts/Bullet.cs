using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    Vector2 startPosition;
    public bool isArrow, isRifleBullet, isPistolBullet, isSniperBullet;

    public float thrust = 45f;

    public int damage = 10;

    public GameObject bulletHitPrefab;

    void Start()
    {
        rb.velocity = transform.right * speed;
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.tag != "Bullet" && other.tag != "EnemyBullet")
        {
            Destroy(gameObject);
            GameObject bulletHit = Instantiate(bulletHitPrefab, transform.position, transform.rotation) as GameObject;

            Destroy(bulletHit, .8f);

            if (other.tag == "Enemy")
            {
                other.attachedRigidbody.AddForce(transform.right * thrust);
                EnemyHealth enemy = other.GetComponent<EnemyHealth>();
                enemy.DamageEnemy(damage);
            }
            else if (other.tag == "Ground")
            {
                //if (isArrow)
                //{
                //    AudioManager.instance.PlaySFX(16);
                //}
                if (isArrow)
                    AudioManager.instance.PlaySFX(9);
                else if (isRifleBullet)
                    AudioManager.instance.PlaySFX(17);
                else if (isSniperBullet)
                {
                    AudioManager.instance.PlaySFX(21);
                }
                else if (isPistolBullet)
                    AudioManager.instance.PlaySFX(22);
                //} else
                //    AudioManager.instance.PlaySFX(Random.Range(11, 15));
            } 
            

            


        }
        if (bulletHitPrefab == null) return;
    }
}


