using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 direction;

    public float lifetime;

    private float lifetimeSeconds;

    private Rigidbody2D projectileBody;

    private void Awake()
    {
        projectileBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        lifetimeSeconds = lifetime;
    }

    private void Update()
    {
        lifetimeSeconds -= Time.deltaTime;

        if (lifetimeSeconds <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 initialVelocity)
    {
        projectileBody.velocity = initialVelocity * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
