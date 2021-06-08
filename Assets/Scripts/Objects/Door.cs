using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key, enemy, button
}

public class Door : Interactables
{
    public DoorType thisDoor;

    public bool isOpen;

    public Inventory playerInventory;

    private SpriteRenderer doorRenderer;
    private BoxCollider2D doorContextCollider;

    public BoxCollider2D doorCollider;  

    private GameObject door;

    private void Awake()
    {
        doorRenderer = GetComponentInParent<SpriteRenderer>();
        doorContextCollider = GetComponent<BoxCollider2D>();

        if(thisDoor == DoorType.enemy)
        {
            OpenDoor();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(playerInRange && thisDoor == DoorType.key)
            {
                if(playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    OpenDoor();
                }
            }
        }
    }

    public void OpenDoor()
    {
        doorRenderer.enabled = false;
        doorCollider.enabled = false;
        doorContextCollider.enabled = false;

        isOpen = true;
    }

    public void CloseDoor()
    {
        doorRenderer.enabled = true;
        doorCollider.enabled = true;
        doorContextCollider.enabled = true;

        isOpen = false;
    }
}
