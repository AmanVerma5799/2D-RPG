using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI    ;

public class Coin : PowerUps
{
    public Inventory playerInventory;

    private void Start()
    {
        powerupSignal.Raise();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.coins += 1;

            powerupSignal.Raise();
            Destroy(gameObject);
        }
    }
}
