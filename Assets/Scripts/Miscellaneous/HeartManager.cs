using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;

    public Sprite fullHeart, halfHeart, emptyHeart;

    public FloatValue heartContainers, playerCurrentHealth;

    void Start()
    {
        InitializeHearts();
    }

    public void InitializeHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runtimeValue / 2;

        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if(i <= tempHealth - 1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfHeart;
            }
        }
    }
}
