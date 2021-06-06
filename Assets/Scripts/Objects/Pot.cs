using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator potAnimator;

    void Awake()
    {
        potAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Smash()
    {
        potAnimator.SetBool("smash", true);
        StartCoroutine(DisableObject());
    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
