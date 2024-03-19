using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    
    [SerializeField]private float waitToEnd=3f;
    [SerializeField] private string gameWin;
    [SerializeField] private GameObject playerGameObject;

    private PlayerController thePlayer;
    private bool isEnding;

    private void Start()
    {
        thePlayer = playerGameObject?.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isEnding==false)
        {
            isEnding = true;
            Invoke(nameof(EndLevelCo), waitToEnd);

        }
    }

    private void EndLevelCo()
    {
        SceneManager.LoadScene(gameWin);
    }
}
