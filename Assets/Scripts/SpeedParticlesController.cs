using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticlesController : MonoBehaviour
{
    private Transform parentTransform;
    private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule emissionModule;


    
    private static float particlesBasis = 35f; // amount of particles emitted per unit based on speed
    public float minSpeedThreshold = 1f; // Minimum speed threshold for emitting particles
    public float maxSpeedThreshold = 10f; // Maximum speed threshold for maximum particle emission rate

    private void Start()
    {
        parentTransform = transform.parent;
        particleSystem = GetComponent<ParticleSystem>();

        emissionModule = particleSystem.emission;

    }

    private void Update()
    {
        // update facing direction to always face backwards
        Vector2 velocity = parentTransform.GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(-velocity.y, -velocity.x) * Mathf.Rad2Deg;
        particleSystem.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // update emission rate depending on speed
        float emissionRate = Remap(velocity.magnitude, minSpeedThreshold, maxSpeedThreshold, 0.5f, 7f);
        emissionModule.rateOverDistance = particlesBasis * emissionRate;
    }

    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return Mathf.Lerp(toMin, toMax, Mathf.InverseLerp(fromMin, fromMax, value));
    }
}
