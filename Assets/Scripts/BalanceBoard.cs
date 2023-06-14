using UnityEngine;
using UnityEngine.InputSystem;

public class BalanceBoard : MonoBehaviour
{

    private Rigidbody2D rb;
    private static Vector2 lu = new Vector2(-1,1);
    private static Vector2 ll = new Vector2(-1,-1);
    private static Vector2 ru = new Vector2(1,1);
    private static Vector2 rl = new Vector2(1,-1);

    public float acceleration = 5.0f;

    public InputAction moveInput;
    public InputAction amplifierInput;

    private bool isAmplified;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput.Enable();
        amplifierInput.Enable();
        amplifierInput.performed += ctx => isAmplified = true;
    }

    // Update is called once per frame
    void Update()
    {
        // var forceVector = InterpretInput(leftUpper.ReadValue<float>(), rightUpper.ReadValue<float>(), leftLower.ReadValue<float>(), rightLower.ReadValue<float>());
        
    }
    void FixedUpdate(){
        Vector2 movement = moveInput.ReadValue<Vector2>();
        if(isAmplified){
            rb.AddForce(acceleration * 2 * movement.normalized);
        }
        else {
            rb.AddForce(acceleration * movement.normalized);
        }
        isAmplified =  false;
    }

    private Vector2 InterpretInput(float leftUpper, float rightUpper, float leftLower, float rightLower)
    {
        Vector2 result = Vector2.zero;
        if(leftUpper != -1.0f){
            result += Mathf.Abs(leftUpper) * lu;
        }
        if(rightUpper != -1.0f){
            result += Mathf.Abs(rightUpper) * ru;
        }
        if(leftLower != 1.0f){
            result += Mathf.Abs(leftLower) * ll;
        }
        if(rightLower != -1.0f){
            result += Mathf.Abs(rightLower) * rl;
        }
        return result.normalized;
    }
}
