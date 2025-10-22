using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealPickup : MonoBehaviour
{
    public GameObject PickupEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            playerHealth.ReceiveHealing(playerHealth.maximumHealth);
            if (PickupEffect != null)
            {
                Instantiate(PickupEffect, transform.position, Quaternion.identity, null);
            }
            Destroy(this.gameObject);
        }
    }

}
