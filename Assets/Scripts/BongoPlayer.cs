using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BongoPlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    private static Vector2 lu = new Vector2(-1,1);
    private static Vector2 ll = new Vector2(-1,-1);
    private static Vector2 ru = new Vector2(1,1);
    private static Vector2 rl = new Vector2(1,-1);

    public float force = 15.0f;

    public InputAction leftUpper;
    public InputAction leftLower;
    public InputAction rightUpper;
    public InputAction rightLower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftUpper.Enable();
        leftLower.Enable();
        rightUpper.Enable();
        rightLower.Enable();

        leftUpper.started += ctx => rb.AddForce(force * lu);
        leftLower.started += ctx => rb.AddForce(force * ll);
        rightUpper.started += ctx => rb.AddForce(force * ru);
        rightLower.started += ctx => rb.AddForce(force * rl);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
