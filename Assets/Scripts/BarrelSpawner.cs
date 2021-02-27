using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public float timeToSpawnBarrels;
    float timeBetweenBarrelWaves;
    public GameObject barrelPrefab;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenBarrelWaves = Random.Range(12f, 25f);
        if (Time.timeSinceLevelLoad > timeToSpawnBarrels)
        {
            SpawnBarrel();

            timeToSpawnBarrels = Time.timeSinceLevelLoad + timeBetweenBarrelWaves;
        }
    }

    void SpawnBarrel()
    {
        Vector2 randomPoint = new Vector2(Random.Range(-11f, 13f), 9f);

        GameObject barrel = Instantiate(barrelPrefab, randomPoint, Quaternion.identity) as GameObject;


    }
}
