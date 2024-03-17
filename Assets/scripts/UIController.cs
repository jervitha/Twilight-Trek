using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Image[] heartIcons;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private string mainMenuScene;
 
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseunPause();
        }
    }

    public void HealthDisplay(int health)
    {
        for(int i=0;i<heartIcons.Length;i++)
        {
            heartIcons[i].enabled = true;
            if(health<=i)
            {
                heartIcons[i].enabled = false;
            }
        }
    }

    public void UpdateLivesDisplay(int currentLives)
    {
        livesText.text = currentLives.ToString();
    }

    public void ShowGameOver()
    {
        gameoverScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }
    public void PauseunPause()
    {
        if(pauseScreen.activeSelf==false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;

    }

   
}
