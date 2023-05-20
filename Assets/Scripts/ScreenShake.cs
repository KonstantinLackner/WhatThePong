using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;    // Duration of the screen shake
    public float shakeMagnitude = 0.1f;   // Intensity of the shake effect
    public AnimationCurve shakeCurve;     // Curve defining the shake pattern

    private float shakeTimer;             // Timer for tracking the shake duration
    private float intensityMultiplier;
    private Vector3 initialPosition;      // Initial position of the camera

    private void Start()
    {
        // Store the initial position of the camera
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        // If the shake timer is active
        if (shakeTimer > 0f)
        {
            // Generate a random offset using the shakeMagnitude and shakeCurve
            Vector2 shakeOffset = shakeMagnitude * intensityMultiplier * shakeCurve.Evaluate((shakeDuration - shakeTimer) / shakeDuration) * Random.insideUnitCircle;
    
            // Apply the offset to the camera position
            transform.localPosition = initialPosition + (Vector3)shakeOffset;

            // Decrease the shake timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the camera position to the initial position
            transform.localPosition = initialPosition;
        }
    }

    public void Shake(float impactIntensity)
    {
        // Start the screen shake effect by setting the shake timer to the shake duration
        intensityMultiplier = Remap(impactIntensity, 0f, 10f, 0.5f, 2f);
        shakeTimer = shakeDuration * intensityMultiplier;
    }

    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return Mathf.Lerp(toMin, toMax, Mathf.InverseLerp(fromMin, fromMax, value));
    }
}

