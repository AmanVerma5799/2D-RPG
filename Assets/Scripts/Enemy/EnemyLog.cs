using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLog : Enemy
{
    [HideInInspector] public Transform target;
    [HideInInspector] public Rigidbody2D enemyBody;
    [HideInInspector] public Animator logAnimator;

    //public Transform homePosition;

    public GameObject deathEffect;

    public float chaseRadius;
    public float attackRadius;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        enemyBody = GetComponent<Rigidbody2D>();
        logAnimator = GetComponent<Animator>();

        currentState = EnemyState.idle;
    }

    private void Start()
    {
        logAnimator.SetBool("setAwake", true);
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 moveVector = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                enemyBody.MovePosition(moveVector);

                ChangeAnimation(moveVector - transform.position);
                ChangeState(EnemyState.walk);
                logAnimator.SetBool("setAwake", true);
            }
        }

        else
        {
            logAnimator.SetBool("setAwake", false); 
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    public void ChangeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimatorVector(Vector2.right);
            }
            else if(direction.x < 0)
            {
                SetAnimatorVector(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0)
            {
                SetAnimatorVector(Vector2.up);
            }
            if(direction.y < 0)
            {
                SetAnimatorVector(Vector2.down);
            }
        }
    }

    private void SetAnimatorVector(Vector2 setVector)
    {
        logAnimator.SetFloat("moveX", setVector.x);
        logAnimator.SetFloat("moveY", setVector.y);
    }

    public void EnemyCouroutine(float knockTime, float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DeathEffect();

            this.gameObject.SetActive(false);
        }

        if(gameObject.activeInHierarchy == true)
        {
            StartCoroutine(KnockEnemy(knockTime));
        }
    }

    IEnumerator KnockEnemy(float knockTime)
    {
        if(enemyBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemyBody.velocity = Vector2.zero;

            currentState = EnemyState.idle;
            enemyBody.velocity = Vector2.zero;
        }
    }

    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
