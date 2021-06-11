using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{
    public Slider magicSlider;

    public Inventory playerInventory;

    private void Start()
    {
        magicSlider.maxValue = playerInventory.maxMagic;
        magicSlider.value = playerInventory.maxMagic;
        playerInventory.currentMagic = playerInventory.maxMagic;
    }

    public void AddMagic()
    {
        magicSlider.value += 2;
        playerInventory.currentMagic += 2;

        if (magicSlider.value > magicSlider.maxValue)
        {
            magicSlider.value = magicSlider.maxValue;
            playerInventory.currentMagic = playerInventory.maxMagic;
        }
    }

    public void RemoveMagic()
    {
        magicSlider.value -= 1;
        playerInventory.currentMagic -= 1;

        if (magicSlider.value < 0)
        {
            magicSlider.value = 0;
            playerInventory.currentMagic = 0;
        }
    }
}
