using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody rb = null;
    private float moveSpeed = 10f;
    [SerializeField] GameObject groundCheck;
    public bool canJump = false;


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            canJump = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            canJump = false;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            
        }
        else if (!canJump)
        {
            moveVector.y = 0;
            rb.AddForce(0, -50, 0);
        }
        
        rb.velocity = moveVector * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
