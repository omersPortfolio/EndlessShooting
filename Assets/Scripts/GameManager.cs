using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{

    public GameObject pistol, rifle, sniper, sword, bow;
    private bool isPistol, isRifle, isSniper, isBow;

    public GameObject enemyPrefab, pauseMenu;
    [HideInInspector]
    public GameObject enemyClone;
    public GameObject spawningEffect;

    Difficulty difficulty = new Difficulty();


    public float timeToSpawnEnemies;
    float timeBetweenEnemyWaves;

    public static GameManager gm;

    void Awake()
    {

        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>(); 
        }
    }

    void Start()
    {
        //Cursor.visible = false;
        ResetSpawnTimer();

        if (PlayerPrefs.HasKey("rifle"))
        {
            ActivateWeapon(rifle.name);
            isRifle = true;
        }
        else if (PlayerPrefs.HasKey("pistol"))
        {
            ActivateWeapon(pistol.name);
            isPistol = true;
        }
        else if (PlayerPrefs.HasKey("sniper"))
        {
            ActivateWeapon(sniper.name);
            isSniper = true;
        }
        else if (PlayerPrefs.HasKey("sword"))
        {
            ActivateWeapon(sword.name);
        }
        else if (PlayerPrefs.HasKey("bow"))
        {
            ActivateWeapon(bow.name);
            isBow = true;
        }
    }

    void Update()
    {
        if (Time.time >= timeToSpawnEnemies)
        {

            StartCoroutine(SpawnEnemy());

            timeToSpawnEnemies = Time.time + timeBetweenEnemyWaves;
        }

        SetDifficulty();
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 randomPoint = new Vector2(Random.Range(-12f, 12f), Random.Range(-2.8f, 0.15f));


        GameObject spawnEffect = Instantiate(spawningEffect, randomPoint, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1.5f);

        enemyClone = Instantiate(enemyPrefab, spawnEffect.transform.position, Quaternion.identity) as GameObject;
        Destroy(spawnEffect);
    }

    public bool ResetSpawnTimer()
    {
        if (gm != null)
        {
            timeToSpawnEnemies = Time.time + 4;
            return true;
        }
        return false;
    }

    public void ActivateWeapon(string weaponToBeActivated)
    {
        pistol.SetActive(weaponToBeActivated.Equals(pistol.name));
        rifle.SetActive(weaponToBeActivated.Equals(rifle.name));
        sniper.SetActive(weaponToBeActivated.Equals(sniper.name));
        sword.SetActive(weaponToBeActivated.Equals(sword.name));
        bow.SetActive(weaponToBeActivated.Equals(bow.name));
    }


    #region Kill Player
    public static void KillPlayer(PlayerHealth player)
    {
        gm._KillPlayer(player);
    }

    public void _KillPlayer(PlayerHealth _player)
    {
        AudioManager.instance.PlaySFX(23);
        GameObject clone = Instantiate(_player.deathParticles.gameObject, _player.transform.position, Quaternion.identity) as GameObject;
        Destroy(clone, 5);
        Destroy(_player.gameObject);
    }
    #endregion



    #region Kill Enemy
    public static void KillEnemy(EnemyHealth enemy)
    {
        gm._KillEnemy(enemy);
    }

    public void _KillEnemy(EnemyHealth _enemy)
    {
        AudioManager.instance.PlaySFX(Random.Range(18, 20));
        GameObject clone = Instantiate(_enemy.deathParticles.gameObject, _enemy.transform.position, Quaternion.identity) as GameObject;
        Destroy(clone, 5);
        Destroy(_enemy.gameObject);
        Score.instance.ScoreUp();
    }

    #endregion 

    

    // Sets the difficulty based on Time.time and assigns the enums
    void SetDifficulty()
    {

        if (Time.timeSinceLevelLoad <= 20)
        {
            difficulty = Difficulty.Beginner;

            if (isPistol)
                timeBetweenEnemyWaves = Random.Range(3.6f, 4.5f);
            else if (isRifle)
                timeBetweenEnemyWaves = Random.Range(2.2f, 3.3f);
            else if (isSniper)
                timeBetweenEnemyWaves = Random.Range(2f, 3.1f);
            else if (isBow)
                timeBetweenEnemyWaves = Random.Range(2.2f, 3.2f);
        }
        else if (Time.timeSinceLevelLoad > 20 && Time.time <= 35)
        {
            difficulty = Difficulty.Easy;
            if (isPistol)
                timeBetweenEnemyWaves = Random.Range(3.3f, 4.2f);
            else if (isRifle)
                timeBetweenEnemyWaves = Random.Range(2f, 3f);
            else if (isSniper)
                timeBetweenEnemyWaves = Random.Range(1.8f, 2.9f);
            else if (isBow)
                timeBetweenEnemyWaves = Random.Range(1.9f, 2.8f);
        }
        else if (Time.timeSinceLevelLoad > 35 && Time.time <= 50)
        {
            difficulty = Difficulty.Medium;
            if (isPistol)
                timeBetweenEnemyWaves = Random.Range(2.85f, 3.5f);
            else if (isRifle)
                timeBetweenEnemyWaves = Random.Range(1.6f, 2.5f);
            else if (isSniper)
                timeBetweenEnemyWaves = Random.Range(1.6f, 2.7f);
            else if (isBow)
                timeBetweenEnemyWaves = Random.Range(1.5f, 2.4f);
        }
        else if (Time.timeSinceLevelLoad > 50 && Time.time <= 65)
        {
            difficulty = Difficulty.Hard;

            if (isPistol)
                timeBetweenEnemyWaves = Random.Range(2.4f, 3f);
            else if (isRifle)
                timeBetweenEnemyWaves = Random.Range(1.45f, 2.1f);
            else if (isSniper)
                timeBetweenEnemyWaves = Random.Range(1.4f, 2.2f);
            else if (isBow)
                timeBetweenEnemyWaves = Random.Range(1.3f, 2f);

        }
        else if (Time.timeSinceLevelLoad > 65)
        {
            difficulty = Difficulty.VeryHard;
            if (isPistol)
                timeBetweenEnemyWaves = Random.Range(1.9f, 2.5f);
            else if (isRifle)
                timeBetweenEnemyWaves = Random.Range(1.5f, 1.65f);
            else if (isSniper)
                timeBetweenEnemyWaves = Random.Range(1.1f, 1.8f);
            else if (isBow)
                timeBetweenEnemyWaves = Random.Range(1f, 1.6f);
        }
        else if (Time.timeSinceLevelLoad > 80)
        {
            difficulty = Difficulty.Extreme;
            if (isPistol)
                timeBetweenEnemyWaves = Random.Range(1.9f, 2.5f);
            else if (isRifle)
                timeBetweenEnemyWaves = Random.Range(1.5f, 1.65f);
            else if (isSniper)
                timeBetweenEnemyWaves = Random.Range(.9f, 1.5f);
            else if (isBow)
                timeBetweenEnemyWaves = Random.Range(1f, 1.6f);
        }
    }
}
