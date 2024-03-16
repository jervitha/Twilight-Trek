using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private Image[] heartIcons;
    [SerializeField] private TMP_Text livesText;
 
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
}
