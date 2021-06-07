using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGuardLog : EnemyLog
{
    public Collider2D enemyBounds;

    public override void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius && enemyBounds.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 moveVector = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                enemyBody.MovePosition(moveVector);

                ChangeAnimation(moveVector - transform.position);
                ChangeState(EnemyState.walk);
                logAnimator.SetBool("setAwake", true);
            }
        }

        else if(distance > chaseRadius || !enemyBounds.bounds.Contains(target.transform.position))
        {
            logAnimator.SetBool("setAwake", false);
        }
    }
}
