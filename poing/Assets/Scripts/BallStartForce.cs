using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float randomFactor = 0.5f; // Adjust this to control the randomness
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector2 newVelocity = rb.velocity + randomDirection * randomFactor;

            // Ensure the speed remains constant
            newVelocity = newVelocity.normalized * speed;

            // Ensure horizontal and vertical movement
            if (Mathf.Abs(newVelocity.x) < 0.1f)
            {
                newVelocity.x = Mathf.Sign(newVelocity.x) * 0.1f;
            }
            if (Mathf.Abs(newVelocity.y) < 0.1f)
            {
                newVelocity.y = Mathf.Sign(newVelocity.y) * 0.1f;
            }

            rb.velocity = newVelocity;
        }
    }
}
