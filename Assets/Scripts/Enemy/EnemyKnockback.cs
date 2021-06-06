using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public float knockbackForce, waitTime, damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();

            if(hit != null)
            {
                hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;

                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * knockbackForce;
                hit.AddForce(difference, ForceMode2D.Impulse);

                hit.GetComponent<PlayerMovement>().PlayerCoroutine(waitTime, damage);
            }
        }
    }
}