using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public bool isActive;
    public BoolValue activeStatus;

    public Sprite activeSprite;

    public Door thisDoor;

    private SpriteRenderer switchRenderer;

    private void Awake()
    {
        switchRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        isActive = activeStatus.runtimeValue;

        if(isActive)
        {
            ActivateSwitch();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        isActive = true;
        activeStatus.runtimeValue = isActive;

        thisDoor.OpenDoor();

        switchRenderer.sprite = activeSprite;
    }
}
