using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GuitarPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //moveInput.Enable();
    }

    void Update()
    {
        //movement = moveInput.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Move the player using physics in FixedUpdate
        if(Input.GetKeyDown(KeyCode.W)){
            rb.MovePosition(rb.position + Vector2.up * moveSpeed);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            rb.MovePosition(rb.position + Vector2.left * moveSpeed);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            rb.MovePosition(rb.position + Vector2.down * moveSpeed);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            rb.MovePosition(rb.position + Vector2.right * moveSpeed);
        }
    }

    public void Move(InputAction.CallbackContext context){
        //movement = context.ReadValue<Vector2>();
    }
}
