using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine;

public class BallController : MonoBehaviour
{
    public ParticleSystem collisionParticles; // Particle system for collision particles

    public Transform SpeedTransform;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Shake screen on collision with player
        
    }
}

