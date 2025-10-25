using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 50f;
    public float acceleration = 10f; 
    public float brakeForce = 20f;
    public float turnSensitivity = 80f;

    private Rigidbody rb;
    private Vector3 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }
    void FixedUpdate()
    {
        ApplyMovement();
    }

    void HandleInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Debug.Log(Mathf.Clamp(movementInput.z, -1, 1));

        movementInput.x = horizontal * turnSensitivity * Mathf.Clamp(movementInput.z,-1,1);
        movementInput.z = Mathf.Clamp(vertical * acceleration, -brakeForce, maxSpeed);
    }

    void ApplyMovement()
    {
        Quaternion rotationDelta = Quaternion.Euler(0, movementInput.x, 0);
        transform.rotation *= rotationDelta;

        rb.AddRelativeForce(Vector3.forward * movementInput.z);
    }
}