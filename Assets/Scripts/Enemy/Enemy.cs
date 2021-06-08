using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle, walk, attack, stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;

    public float health, baseAttack;
    public string enemyName;
    public float moveSpeed;

    public Vector2 homePosition;

    public GameObject deathEffect;

    public FloatValue maxHealth;

    public LootTable enemyLoot;

    public Signal roomEnemyDead;

    private void Start()
    {
        health = maxHealth.initialValue;
    }

    private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    public void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    public void DropLoot()
    {
        if(enemyLoot)
        {
            PowerUps current = enemyLoot.LootPowerups();

            if(current)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
