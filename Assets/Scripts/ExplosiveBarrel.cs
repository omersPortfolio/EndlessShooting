using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{

    public GameObject explosionParticle;
    PlayerController player;
    CameraShake cameraShake;

    void Awake()
    {
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet" || other.tag == "EnemyBullet")
        {
            Explosion();
            CameraShake.instance.Shake(0.05f, 0.1f);
        }
    }

    void Explosion()
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(explosion, 0.4f);
    }
}
