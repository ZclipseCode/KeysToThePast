using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    //private bool groundedPlayer;

    [SerializeField]
    public MovementStates mState;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    [SerializeField] GameObject groundCheck;
    [SerializeField] bool isGrounded;

    [SerializeField] Rigidbody rb;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            isGrounded = false;
        }
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        
        //if (isGrounded && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}

        //print(movementInput.x);

        
        Vector3 move = new Vector3(movementInput.x, 0, 0);
        
        if (!isGrounded) {
            mState = MovementStates.AIRBORNE;
        }
        else if (movementInput.y < -.5) {
            mState = MovementStates.CROUCHING;
        }
        else if(movementInput.x < 0) {
            mState = MovementStates.WALKINGLEFT;
        }
        else if(movementInput.x > 0) {
            mState = MovementStates.WALKINGRIGHT;
        }
        else {
            mState = MovementStates.STANDING;
        }

        if (movementInput.y > -.5 || mState == MovementStates.AIRBORNE)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }


        // Changes the height position of the player..
        if (jumped && isGrounded)
        {
            playerVelocity.y += jumpHeight * -3.0f * gravityValue * Time.deltaTime;
            print("jumped");
            //rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

public enum MovementStates {
    STANDING,
    CROUCHING,
    WALKINGRIGHT,
    WALKINGLEFT,
    AIRBORNE,
}
