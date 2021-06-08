using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public Pot[] pots;

    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                ChangeActiveState(enemies[i], true);
            }

            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActiveState(pots[i], true);
            }

            virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActiveState(enemies[i], false);
            }

            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActiveState(pots[i], false);
            }

            virtualCamera.SetActive(false);
        }
    }

    public void ChangeActiveState(Component component, bool activeStatus)
    {
        component.gameObject.SetActive(activeStatus);
    }
}
