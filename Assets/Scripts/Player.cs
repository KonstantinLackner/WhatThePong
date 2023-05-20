using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public InputAction moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput.Enable();
    }

    void Update()
    {
        movement = moveInput.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Move the player using physics in FixedUpdate
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext context){
        //movement = context.ReadValue<Vector2>();
    }
}
