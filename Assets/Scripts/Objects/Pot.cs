using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator potAnimator;

    //public GameObject coin;

    void Awake()
    {
        potAnimator = GetComponent<Animator>();
    }

    public void Smash()
    {
        potAnimator.SetBool("smash", true);

        //GameObject coinDrop = Instantiate(coin, transform.position + buffer, Quaternion.identity);

        StartCoroutine(DisableObject());
    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
