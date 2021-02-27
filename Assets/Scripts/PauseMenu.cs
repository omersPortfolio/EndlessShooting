using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused;
    Weapon weapon;
    GunRotation gunRotation;


    private void Start()
    {
        weapon = FindObjectOfType<Weapon>();
        gunRotation = FindObjectOfType<GunRotation>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }

    }

    public void MainMenuu()
    {
        MainMenu.instance.ResetColors();
       
        SceneManager.LoadScene("EmptyScene");
        GameMenuController.instance.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseControl()
    {
        if (isPaused)
        {
            gunRotation.enabled = true;
            weapon.enabled = true;
            Time.timeScale = 1;
            isPaused = false;
            pausePanel.SetActive(false);
        }

        else
        {
            gunRotation.enabled = false;
            weapon.enabled = false;
            Time.timeScale = 0;
            isPaused = true;
            pausePanel.SetActive(true);
        }
    }
}
