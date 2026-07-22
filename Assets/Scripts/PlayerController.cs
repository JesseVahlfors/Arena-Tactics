using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public InputAction moveAction;
    private Rigidbody playerRb;
    private Vector2 moveInput;
    public float horizontalInput;
    public float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        Vector3 moveDirection = new(horizontalInput, 0f, verticalInput);

        transform.position += moveSpeed * Time.deltaTime * moveDirection;
    }
}
