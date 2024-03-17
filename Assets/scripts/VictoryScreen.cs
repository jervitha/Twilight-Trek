using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private string mainMenu;
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
