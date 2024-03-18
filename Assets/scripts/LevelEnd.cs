using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private bool isEnding;
    [SerializeField]private float waitToEnd=3f;
    [SerializeField] private string gameWin;
    [SerializeField] private GameObject playerGameObject;
    private PlayerController thePlayer;

    private void Start()
    {
        thePlayer = playerGameObject?.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isEnding==false)
        {
            isEnding = true;
            StartCoroutine(EndLevelCo());

        }
    }
    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToEnd);
        SceneManager.LoadScene(gameWin);
      
    }
}
