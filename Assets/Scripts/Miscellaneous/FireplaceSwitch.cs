using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceSwitch : MonoBehaviour
{
    private SpriteRenderer fireRenderer;

    private bool playerInrange, islit;

    public Sprite fireLit;

    private void Awake()
    {
        fireRenderer = GetComponent<SpriteRenderer>();
        islit = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInrange)
        {
            islit = !islit;
            ChangeState();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerInrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInrange = false;
        }
    }

    private void ChangeState()
    {
        if(islit)
        {
            fireRenderer.sprite = fireLit;
        }
        else
        {
            fireRenderer.sprite = null;
        }
    }
}
