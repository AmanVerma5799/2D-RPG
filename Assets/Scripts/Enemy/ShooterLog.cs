using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterLog : EnemyLog
{
    public GameObject rockProjectile;

    public float fireDelay;

    private float fireDelaySeconds;

    private bool canFire;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;

        if(fireDelaySeconds <= 0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    public override void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 tempVector = target.position - transform.position;

                if(canFire)
                {
                    GameObject currentProjectile = Instantiate(rockProjectile, transform.position, Quaternion.identity);
                    currentProjectile.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;
                }

                ChangeState(EnemyState.walk);
                logAnimator.SetBool("setAwake", true);
            }
        }

        else if (distance > chaseRadius)
        {
            logAnimator.SetBool("setAwake", false);
        }
    }
}
