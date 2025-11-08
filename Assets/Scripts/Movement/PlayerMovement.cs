using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    public float crouchYScale;
    private float startYScale;
    public float staminaDuration;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    UnityEngine.Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        movingIntoWalk,
        air
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

        startYScale = transform.localScale.y;
    }

    void Update()
    {
        //check if player is grounded 
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        TrackInput();
        SpeedControl();
        StateHandler();

        //handle drag
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        if (staminaDuration <= 0)
            staminaDuration = 0;

        if (staminaDuration >= 4)
        {
            staminaDuration = 4;
        }

    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void TrackInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //queue jump 
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        //Is crouching
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new UnityEngine.Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(UnityEngine.Vector3.down * 5f, ForceMode.Impulse);
        }

        //not crouching 
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new UnityEngine.Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void StateHandler()
    {

        //"Ride like the wind" - Christopher Cross 
        // RUNNING
        if (grounded && Input.GetKey(sprintKey) && staminaDuration > 0)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
            staminaDuration -= Time.deltaTime;
        }

        //"Walk it like I talk it" - Migos 
        // WALKING
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
            if (staminaDuration < 4)
            {
                staminaDuration += Time.deltaTime;
            }
        }

        //I cant come up with a song for short people
        //CROUCHING
        else if (grounded && Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
            if (staminaDuration < 4)
            {
                staminaDuration += Time.deltaTime;
            }
        }

        //AIR
        else
        {
            state = MovementState.air;
        }


    }
    

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);


    }

    private void SpeedControl()
    {
        UnityEngine.Vector3 flatVel = new UnityEngine.Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit the speed of the player if it gets higher than desired speed
        if (flatVel.magnitude > moveSpeed)
        {
            UnityEngine.Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new UnityEngine.Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.linearVelocity = new UnityEngine.Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

}