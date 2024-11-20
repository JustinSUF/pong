using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRigidbody : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystem ps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps.isPlaying)
        {
            // Example: Move the Rigidbody2D based on particle velocity
            var main = ps.main;
            rb.velocity = main.startSpeed.constant * transform.forward;
        }
    }
}
