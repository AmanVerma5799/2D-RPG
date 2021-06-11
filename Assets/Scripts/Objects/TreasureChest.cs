using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactables  
{
    public Item content;
    public Inventory playerInventory;

    [SerializeField] private bool isOpen;

    public BoolValue alreadyOpened;

    public Signal raiseItem;

    public GameObject dialogueBox;
    public Text dialogue;

    private Animator chestAnimator;

    public FloatValue heartContainer;
    public FloatValue playerHealth;

    public Signal healthSignal;

    private void Awake()
    {
        chestAnimator = GetComponentInParent<Animator>();

        isOpen = alreadyOpened.runtimeValue;

        if (isOpen)
        {
            chestAnimator.SetBool("isOpened", true);
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if(!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestOpened();
            }
        }
    }

    public void OpenChest()
    {
        dialogueBox.SetActive(true);
        dialogue.text = content.itemDescription;

        playerInventory.AddItem(content);
        playerInventory.currentItem = content;

        raiseItem.Raise();
        contextOff.Raise();

        chestAnimator.SetBool("isOpened", true);

        isOpen = true;

        alreadyOpened.runtimeValue = isOpen;

        if(healthSignal && heartContainer)
        {
            CheckForContainer();
        }
    }

    public void ChestOpened()
    {
        dialogueBox.SetActive(false);

        raiseItem.Raise();
    }

    public void CheckForContainer()
    {
        if(playerInventory.CheckForItem(content))
        {
            heartContainer.runtimeValue += 1;
            playerHealth.runtimeValue = heartContainer.runtimeValue * 2;

            healthSignal.Raise();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger && !isOpen)
        {
            playerInRange = true;
            contextOn.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger && !isOpen)
        {
            contextOff.Raise();
            playerInRange = false;
        }
    }
}
