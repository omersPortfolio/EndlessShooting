using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Image rifleImage;

    [SerializeField]
    Image pistolImage;

    [SerializeField]
    Image sniperImage;

    //[SerializeField]
    //Image swordImage;

    [SerializeField]
    Image bowImage;

    [SerializeField]
    Text weaponErrorText;

    

    public GameObject mainPanel, aboutPanel, weaponSelectPanel;

    public static MainMenu instance;

    private void Awake()
    {
        instance  = this;
    }

    private void Start()
    {
        
    }

    public void StartGame()
    {
        if (!PlayerPrefs.HasKey("weapon"))
        {
            Debug.Log("No weapon selected");
            weaponErrorText.gameObject.SetActive(true);
            return;
        }
        
        SceneManager.LoadScene("GameScene");
    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            DeletePlayerPrefs();
            ResetColors();
            Debug.Log("Deleted");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Every data is deleted");
        }

        if (PlayerPrefs.HasKey("weapon"))
        {
            weaponErrorText.gameObject.SetActive(false);
        }

        HighScoreText();
    }

    private void HighScoreText()
    {

        
    }

    #region Weapon Select Functions
    public void RifleSelect()
    {
        AudioManager.instance.PlaySFX(5);
        DeletePlayerPrefs();
        PlayerPrefs.SetInt("rifle", 1);
        PlayerPrefs.SetString("weapon", "1");

        rifleImage.color = new Color(.5f, .5f, .5f, 1f);

        sniperImage.color = new Color(1f, 1f, 1f, 1f);
        pistolImage.color = new Color(1f, 1f, 1f, 1f);
        //swordImage.color = new Color(1f, 1f, 1f, 1f);
        bowImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void PistolSelect()
    {
        AudioManager.instance.PlaySFX(7);
        DeletePlayerPrefs();
        PlayerPrefs.SetInt("pistol", 1);
        PlayerPrefs.SetString("weapon", "1");

        pistolImage.color = new Color(.5f, .5f, .5f, 1f);

        rifleImage.color = new Color(1f, 1f, 1f, 1f);
        sniperImage.color = new Color(1f, 1f, 1f, 1f);
        //swordImage.color = new Color(1f, 1f, 1f, 1f);
        bowImage.color = new Color(1f, 1f, 1f, 1f);

    }

    public void SniperSelect()
    {
        AudioManager.instance.PlaySFX(6);
        DeletePlayerPrefs();
        PlayerPrefs.SetInt("sniper", 1);
        PlayerPrefs.SetString("weapon", "1");

        sniperImage.color = new Color(.5f, .5f, .5f, 1f);

        pistolImage.color = new Color(1f, 1f, 1f, 1f);
        rifleImage.color = new Color(1f, 1f, 1f, 1f);
        //swordImage.color = new Color(1f, 1f, 1f, 1f);
        bowImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void SwordSelect()
    {
        DeletePlayerPrefs();
        PlayerPrefs.SetInt("sword", 1);
        PlayerPrefs.SetString("weapon", "1");

        //swordImage.color = new Color(.5f, .5f, .5f, 1f);

        sniperImage.color = new Color(1f, 1f, 1f, 1f);
        pistolImage.color = new Color(1f, 1f, 1f, 1f);
        rifleImage.color = new Color(1f, 1f, 1f, 1f);
        bowImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void BowSelect()
    {
        AudioManager.instance.PlaySFX(10);
        DeletePlayerPrefs();
        PlayerPrefs.SetInt("bow", 1);
        PlayerPrefs.SetString("weapon", "1");

        bowImage.color = new Color(.5f, .5f, .5f, 1f);

        //swordImage.color = new Color(1f, 1f, 1f, 1f);
        sniperImage.color = new Color(1f, 1f, 1f, 1f);
        pistolImage.color = new Color(1f, 1f, 1f, 1f);
        rifleImage.color = new Color(1f, 1f, 1f, 1f);
    }

    #endregion


    public void ActivatePanel(string panelToBeActivated)
    {
        mainPanel.SetActive(panelToBeActivated.Equals(mainPanel.name));
        aboutPanel.SetActive(panelToBeActivated.Equals(aboutPanel.name));
        weaponSelectPanel.SetActive(panelToBeActivated.Equals(weaponSelectPanel.name));
    }

    public void ResetColors()
    {
        bowImage.color = new Color(1f, 1f, 1f, 1f);
        sniperImage.color = new Color(1f, 1f, 1f, 1f);
        pistolImage.color = new Color(1f, 1f, 1f, 1f);
        rifleImage.color = new Color(1f, 1f, 1f, 1f);
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("weapon");
        PlayerPrefs.DeleteKey("rifle");
        PlayerPrefs.DeleteKey("sniper");
        PlayerPrefs.DeleteKey("pistol");
        PlayerPrefs.DeleteKey("bow");

        ResetColors();
    }

    
}
