using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private PlayerHealthController playerHealthController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

         PlayerController otherController = other.gameObject.GetComponent<PlayerController>();

            if (otherController != null)
            {
                 PlayerHealthController.instance.DamagePlayer();
               
            }
        }
    }

