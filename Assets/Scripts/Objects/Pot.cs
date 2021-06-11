using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator potAnimator;

    public LootTable potLoot;


    void Awake()
    {
        potAnimator = GetComponent<Animator>();
    }

    public void Smash()
    {
        potAnimator.SetBool("smash", true);

        StartCoroutine(DisableObject());
        DropLoot();
    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void DropLoot()
    {
        if(potLoot)
        {
            PowerUps current = potLoot.LootPowerups();

            if(current)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
