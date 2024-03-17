using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController otherController = other.gameObject.GetComponent<PlayerController>();

        if (otherController != null)
        {
            PlayerHealthController.instance.DamagePlayer();
        }

    }
   
}
