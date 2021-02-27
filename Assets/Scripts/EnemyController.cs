using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Variables
    public float speed;
    public Rigidbody2D rb;

    GameObject playerPos;

    public float shootingRange;

    public GameObject bullet;
    public GameObject firePoint;

    public float startTimeBtwShots;
    private float timeBtwShots;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    bool isGrounded;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player");

        timeBtwShots = 0;
    }

    
    void Update()
    {

        if (playerPos == null) return;

        float distanceFromPlayer = Vector2.Distance(transform.position, playerPos.transform.position);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatIsGround);

        if (isGrounded)
        {
            if (distanceFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.transform.position.x, transform.position.y), speed * Time.deltaTime);
                
            }

            else if (distanceFromPlayer <= shootingRange && timeBtwShots <= 0)
            {
                
                GameObject clone = Instantiate(bullet, firePoint.transform.position, Quaternion.identity) as GameObject;
                AudioManager.instance.PlaySFX(1);
                Destroy(clone, 2);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }   
    }
}
