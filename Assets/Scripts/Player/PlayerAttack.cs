using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float knockbackForce, waitTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            other.GetComponent<Pot>().Smash();
        }

        if(other.CompareTag("Enemy") && other.isTrigger)
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();

            if (hit != null)
            {
                hit.GetComponent<Enemy>().currentState = EnemyState.stagger;

                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * knockbackForce;
                hit.AddForce(difference, ForceMode2D.Impulse);

                hit.GetComponent<EnemyLog>().EnemyCouroutine(waitTime, damage);
            }
        }
    }
}