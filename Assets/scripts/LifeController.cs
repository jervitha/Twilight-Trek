using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    private PlayerController player;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private Transform startingPoint;
    [SerializeField] private int currentLives=3;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player = playerGameObject?.GetComponent<PlayerController>();
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        player.transform.position = startingPoint.position;
        player.gameObject.SetActive(true);
        currentLives--;
        if(currentLives>0)
        {
            player.transform.position = startingPoint.position;
        }
        else
        {
            currentLives = 0;
            UIController.instance.ShowGameOver();
        }
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }

    }
}
