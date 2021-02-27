using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    int score;
    int highestScore;

    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        

        if (score > highestScore)
        {
            highestScore = score;
            if (PlayerPrefs.GetInt("highestScore") <= highestScore)
            {
                PlayerPrefs.SetInt("highestScore", highestScore);
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteKey("highestScore");
            PlayerPrefs.DeleteKey("pistolScore");
            PlayerPrefs.DeleteKey("rifleScore");
            PlayerPrefs.DeleteKey("sniperScore");
            PlayerPrefs.DeleteKey("bowScore");
            Debug.Log("Scores are deleted");
        }

        WeaponScore();

    }

    private void WeaponScore()
    {
        if (PlayerPrefs.HasKey("pistol"))
        {
            if (PlayerPrefs.GetInt("pistolScore") <= highestScore)
            {
                PlayerPrefs.SetInt("pistolScore", highestScore);
            }
        }
        else if (PlayerPrefs.HasKey("rifle"))
        {
            if (PlayerPrefs.GetInt("rifleScore") <= highestScore)
            {
                PlayerPrefs.SetInt("rifleScore", highestScore);
            }
        }
        else if (PlayerPrefs.HasKey("sniper"))
        {
            if (PlayerPrefs.GetInt("sniperScore") <= highestScore)
            {
                PlayerPrefs.SetInt("sniperScore", highestScore);
            }
        }
        else if (PlayerPrefs.HasKey("bow"))
        {
            if (PlayerPrefs.GetInt("bowScore") <= highestScore)
            {
                PlayerPrefs.SetInt("bowScore", highestScore);
            }
        }
        PlayerPrefs.Save();
    }

    

    public void ScoreUp()
    {
        score += 100;
        
    }
}
