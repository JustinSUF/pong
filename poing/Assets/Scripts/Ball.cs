using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 5f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        currentSpeed = initialSpeed;
        LaunchBallWithDelay();
    }

    void LaunchBall()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
        rb.velocity = randomDirection * currentSpeed;
    }

    void LaunchBallWithDelay()
    {
        rb.velocity = Vector2.zero; // Stop the ball
        StartCoroutine(DelayedLaunch());
    }

    IEnumerator DelayedLaunch()
    {
        yield return new WaitForSeconds(1f); // 1-second delay
        LaunchBall();
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero; // Stop the ball
        transform.position = Vector3.zero; // Reset position to (0, 0, 0)
        currentSpeed = initialSpeed; // Reset speed
        LaunchBallWithDelay(); // Relaunch the ball with delay
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Increment the speed by 0.5
        currentSpeed += 0.5f;

        // Apply a slight random adjustment to the current velocity
        Vector2 randomAdjustment = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        Vector2 newVelocity = (rb.velocity + randomAdjustment).normalized * currentSpeed;

        // Ensure significant horizontal and vertical movement
        if (Mathf.Abs(newVelocity.x) < 0.5f)
        {
            newVelocity.x = Mathf.Sign(newVelocity.x) * 0.5f;
        }
        if (Mathf.Abs(newVelocity.y) < 0.5f)
        {
            newVelocity.y = Mathf.Sign(newVelocity.y) * 0.5f;
        }

        rb.velocity = newVelocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal1" || other.gameObject.tag == "Goal2")
        {
            scoreManager.AddScore(other.gameObject.tag);
            ResetBall();
        }
    }
}
