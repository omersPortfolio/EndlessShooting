using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    public GameObject gameOverPanel;

    float deathTime = 0;
    public bool isDead;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isDead)
        {
            deathTime += Time.deltaTime;

            if (deathTime >= 5f)
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene("EmptyScene");
        
        GameMenuController.instance.gameObject.SetActive(true);
        Time.timeScale = 1;
    }


    public void PlayerDeath()
    {
        StartCoroutine(PlayerDeathCo());
    }

    private IEnumerator PlayerDeathCo()
    {
        isDead = true;

        yield return new WaitForSeconds(2f);
        Time.timeScale = 0.4f;

        gameOverPanel.SetActive(true);

        //Time.timeScale = 0;
    }
}
