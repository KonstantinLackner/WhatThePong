using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticlesController : MonoBehaviour
{
    private Transform parentTransform;
    private ParticleSystem particleSystem;

    private void Start()
    {
        parentTransform = transform.parent;
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        Vector2 velocity = parentTransform.GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(-velocity.y, -velocity.x) * Mathf.Rad2Deg;
        particleSystem.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
