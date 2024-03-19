using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthToAdd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
                PlayerHealthController.instance.AddHealth(healthToAdd);
                Destroy(gameObject);
        }
    }
}
