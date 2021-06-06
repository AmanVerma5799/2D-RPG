using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : EnemyLog
{
    public Transform[] points;

    public float roundingDistance;

    private int currentPoint;

    public override void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 moveVector = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                enemyBody.MovePosition(moveVector);

                ChangeAnimation(moveVector - transform.position);
                logAnimator.SetBool("setAwake", true);
            }
        }

        else if(distance > chaseRadius)
        {
            if(Vector3.Distance(transform.position, points[currentPoint].position) > roundingDistance)
            {
                Vector3 moveVector = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
                enemyBody.MovePosition(moveVector);

                ChangeAnimation(moveVector - transform.position);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal()
    {
        if(currentPoint == points.Length - 1)
        {
            currentPoint--;
        }
        else
        {
            currentPoint++;
        }
    }
}
