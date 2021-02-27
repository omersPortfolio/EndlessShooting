using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour {


    public static GameMenuController instance;
    MainMenu weaponMenu;

    public GameObject menuCanvasObj, mainPanel, weaponPanel;

    private float previousTimescale;
    private bool menuOpen;

    public Text highestScoreText, pistolScoreText, rifleScoreText, sniperScoreText, bowScoreText;

    private void Awake()
    {
        instance = this;
        weaponMenu = GetComponent<MainMenu>();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    
    void Update()
    {
        highestScoreText.text = "HIGHEST SCORE: " + PlayerPrefs.GetInt("highestScore").ToString();
        pistolScoreText.text = "PISTOL: " + PlayerPrefs.GetInt("pistolScore").ToString();
        rifleScoreText.text = "RIFLE: " + PlayerPrefs.GetInt("rifleScore").ToString();
        sniperScoreText.text = "SNIPER: " + PlayerPrefs.GetInt("sniperScore").ToString();
        bowScoreText.text = "BOW: " + PlayerPrefs.GetInt("bowScore").ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && !menuOpen)
        {
            ButtonToggleMenu();
        }

        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "MultiplayerScene")
        {
            
            weaponMenu.ResetColors();
            mainPanel.SetActive(true);
            weaponPanel.SetActive(false);
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteKey("highestScore");
            PlayerPrefs.DeleteKey("pistolScore");
            PlayerPrefs.DeleteKey("rifleScore");
            PlayerPrefs.DeleteKey("sniperScore");
            PlayerPrefs.DeleteKey("bowScore");
            Debug.Log("Scores are deleted");
        }
    }

    public void ButtonToggleMenu()
    {
        if (!menuOpen)
        {
            previousTimescale = Time.timeScale;//getting the current timescale
            Time.timeScale = 0;//Pausing time
            menuCanvasObj.SetActive(true);

            menuOpen = true;
        }
        else
        {
            Time.timeScale = previousTimescale;//unpausing time

            menuOpen = false;
        }
    }

    //for testing/Debugging.
    public void DeletePlayerprefs()
    {
        PlayerPrefs.DeleteKey("graphicsPrefsSaved");
        PlayerPrefs.DeleteKey("FPSToggle");
        PlayerPrefs.DeleteKey("graphicsSlider");
        PlayerPrefs.DeleteKey("antiAliasSlider");
        PlayerPrefs.DeleteKey("shadowResolutionSlider");
        PlayerPrefs.DeleteKey("textureQualitySlider");
        PlayerPrefs.DeleteKey("anisotropicModeSlider");
        PlayerPrefs.DeleteKey("anisotropicLevelSlider");
        PlayerPrefs.DeleteKey("wantedResolutionX");
        PlayerPrefs.DeleteKey("wantedResolutionY");
        PlayerPrefs.DeleteKey("windowedModeToggle");
        PlayerPrefs.DeleteKey("vSyncToggle");

        PlayerPrefs.DeleteKey("audioPrefsSaved");
        PlayerPrefs.DeleteKey("mainVolumeF");
        PlayerPrefs.DeleteKey("fxVolumeF");
        PlayerPrefs.DeleteKey("musicVolumeF");
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }
}
