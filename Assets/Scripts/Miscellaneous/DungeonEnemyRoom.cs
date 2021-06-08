using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public Door[] doors;

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActiveState(enemies[i], true);
            }

            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActiveState(pots[i], true);
            }

            virtualCamera.SetActive(true);
            CloseDoors();
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
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

    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
            else
            {
                OpenDoors();
            }
        }
    }

    public void CloseDoors()
    {
        for(int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].OpenDoor();
        }
    }
}
