using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform firePoint;


    public float fireRate = 1.7f;
    public float fireTimer;
    public GameObject bulletPrefab;

    //[Header("Laser")]
    //Vector2 mouse;
    //RaycastHit hit;
    //float range = 200.0f;
    //LineRenderer line;

    void Start()
    {
        
        //line = GetComponent<LineRenderer>();
        //line.positionCount = 2;
        //line.startColor = Color.red;
        //line.endColor = Color.red;

        fireTimer = fireRate - 0.1f;
    }

    
    void Update()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }


        if (Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0f;
            Shoot();
        }

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, range))
        //{
        //    line.SetPosition(0, transform.position);
        //    line.SetPosition(1, hit.point + hit.normal);
        //}
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Destroy(bullet, 3f);
    }
}
