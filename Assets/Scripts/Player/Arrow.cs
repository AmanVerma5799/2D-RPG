using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;

    private Rigidbody2D arrowBody;

    private void Awake()
    {
        arrowBody = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        arrowBody.velocity = velocity.normalized * speed;

        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 2f);
        }
    }
}
