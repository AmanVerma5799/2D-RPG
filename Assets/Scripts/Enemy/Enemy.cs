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

    public FloatValue maxHealth;

    private void Start()
    {
        health = maxHealth.initialValue;
    }

    private void OnEnable()
    {
        transform.position = homePosition;
    }
}
