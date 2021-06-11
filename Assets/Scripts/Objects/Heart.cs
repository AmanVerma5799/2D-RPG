using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUps
{
    public FloatValue playerHealth;
    public FloatValue heartContainer;

    public float amountToAdd;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.runtimeValue += amountToAdd;

            if(playerHealth.runtimeValue > heartContainer.runtimeValue * 2f)
            {
                playerHealth.runtimeValue = heartContainer.runtimeValue * 2f;
            }

            powerupSignal.Raise();
            Destroy(gameObject);
        }
    }
}
