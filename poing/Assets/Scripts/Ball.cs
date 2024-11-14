using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        LaunchBallWithDelay();
    }

    void LaunchBall()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = randomDirection * speed;
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
        LaunchBallWithDelay(); // Relaunch the ball with delay
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal1" || other.gameObject.tag == "Goal2")
        {
            scoreManager.AddScore(other.gameObject.tag);
            ResetBall();
        }
        else
        {
            LaunchBall(); // Randomize direction on every collision
        }
    }
}
