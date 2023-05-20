using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject spawnPoint;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
    }

    private void Update()
    {
        
    }

    public void ResetPosition()
    {
        gameObject.transform.position = spawnPoint.transform.position;
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0;
    }

    public void ResetPositionWithDelay(float seconds)
    {
        Invoke(nameof(ResetPosition), seconds);
    }
}

