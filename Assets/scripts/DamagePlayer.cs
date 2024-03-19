using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController otherController = other.gameObject.GetComponent<PlayerController>();

            if (otherController != null)
            {
                 PlayerHealthController.instance.DamagePlayer();
               
            }
        }
    }

