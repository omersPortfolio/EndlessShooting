using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject player;
    Vector2 moveDirection;

    public float speed;
    Rigidbody2D bulletRB;
    public GameObject bulletHit;

    int damage = 10;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bulletRB = GetComponent<Rigidbody2D>();

        moveDirection = (player.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y + 1f);
    }

    private void Update()
    {
        if (player == null) return;

        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        //    DestroyBullet();
        //}

       
        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
        GameObject bullet = Instantiate(bulletHit, transform.position, transform.rotation) as GameObject;
        Destroy(bullet, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("EnemyBullet") && !other.CompareTag("Bullet"))
        {
            DestroyBullet();


            if (other.CompareTag("Player")){

                PlayerHealth player = other.GetComponent<PlayerHealth>();
                player.DamagePlayer(damage);
            }
            else if (other.CompareTag("Ground"))
            {
                AudioManager.instance.PlaySFX(22);
            }
        } 

        
           
    }
}
