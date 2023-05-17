using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BallController : MonoBehaviour
{
    public ParticleSystem collisionParticles; // Particle system for collision particles

    public Transform SpeedTransform;

    private Rigidbody2D rb;
    private ScreenShake screenShake;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenShake = Camera.main.GetComponent<ScreenShake>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Shake screen on collision
        if (screenShake != null)
        {
            float impactIntensity = collision.relativeVelocity.magnitude;
            screenShake.Shake(impactIntensity);
        }
    }
}

