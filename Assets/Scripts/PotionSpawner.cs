using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject potionPrefab;

    public float timeToSpawnPotions;
    float timeBetweenPotionWaves;

    private void Start()
    {
        timeBetweenPotionWaves = Random.Range(20f, 35f);
        
    }
    void Update()
    {
        

        if (Time.timeSinceLevelLoad > timeToSpawnPotions)
        {
            SpawnPotions();

            timeToSpawnPotions = Time.timeSinceLevelLoad + timeBetweenPotionWaves;
        }
    }

    void SpawnPotions()
    {
        Vector2 randomPoint = new Vector2(Random.Range(-11f, 13f), 9f);

        Instantiate(potionPrefab, randomPoint, Quaternion.identity);
    }
}
