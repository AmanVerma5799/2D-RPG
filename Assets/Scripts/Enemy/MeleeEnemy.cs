using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyLog
{
    private void Start()
    {
        logAnimator.SetBool("isWalking", false);
    }

    public override void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger && target.gameObject.activeInHierarchy)
            {
                Vector3 moveVector = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                enemyBody.MovePosition(moveVector);

                ChangeAnimation(moveVector - transform.position);
                ChangeState(EnemyState.walk);
                logAnimator.SetBool("isWalking", true);
            }
        }

        else if (distance <= chaseRadius && distance <= attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger && target.gameObject.activeInHierarchy)
            {
                StartCoroutine(MeleeAttackCoroutine());
            }
        }

        else if(distance > chaseRadius)
        {
            ChangeState(EnemyState.idle);
            logAnimator.SetBool("isWalking", false);
        }
    }

    public IEnumerator MeleeAttackCoroutine()
    {
        ChangeState(EnemyState.attack);
        logAnimator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(0.2f);

        ChangeState(EnemyState.walk);
        logAnimator.SetBool("isAttacking", false);
    }
}
