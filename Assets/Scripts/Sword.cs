using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("swing");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.DamageEnemy(100);
        }
    }
}
