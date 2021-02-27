using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    public Weapons weapon;

    public Transform firePoint;

    float fireTimer;
  
    void Start()
    {
        fireTimer = weapon.fireRate - 0.001f;
    }

    void Update()
    {

        if (fireTimer < weapon.fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        
        if (Input.GetButtonDown("Fire1") && fireTimer > weapon.fireRate)
        {
            if (weapon.weaponName == "pistol")
            {
                AudioManager.instance.PlaySFX(0);
            }else if (weapon.weaponName == "sniper")
            {
                AudioManager.instance.PlaySFX(Random.Range(2,3));
            }else if (weapon.weaponName == "bow")
            {
                AudioManager.instance.PlaySFX(8);
            }
            fireTimer = 0f;
            Shoot();

           
        }

        if (weapon.weaponName == "rifle")
        {
            if (Input.GetButton("Fire1") && fireTimer > weapon.fireRate)
            {
                
                fireTimer = 0f;
                Shoot(); 
            }
        }        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(weapon.bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Destroy(bullet, 2f);
        if (weapon.weaponName == "rifle")
        {
            AudioManager.instance.PlayRifleSFX(4);

        }
    }
}
