using FMOD.Studio;
using FMODUnity;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //public int playerWalkSFX = 0;
    //SoundManager.instance.PlaySFX(playerWalkSFX);
    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float idleSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    public float crouchYScale;
    private float startYScale;
    public Transform playerModel;
    public float staminaDuration;
    private bool isCrouching = false;
    private EventInstance playerDirtWalk;
    //public int Walk1SFX = 0;
    //public int Nothing = 0;
    //public WalkSFXManager WalkSFXManager;
    //public GameObject WSFXObject;
    public bool iswalking = false;
    public bool inputNotActive = false;
    //public GameObject PlayerSFX;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public HeadBobV2 headBobScript;
    private bool headbobSprintCheck;
    public Camera camera;

    UnityEngine.Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        idling,
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
        playerDirtWalk = AudioManager.instance.CreateEventInstance(FMODEvents.instance.DirtWalk);
        playerDirtWalk.set3DAttributes(RuntimeUtils.To3DAttributes(playerModel.gameObject));
    }

    void Update()
    {
        //WSFXObject = GameObject.Find("WalkSFXOneShotPrefab(Clone)");
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
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            iswalking = true;
            inputNotActive = false;
        }
        else
        {
            iswalking = false;
            inputNotActive = true;
        }
    }
    //    if (iswalking && grounded)
    //    {
    //        PLAYBACK_STATE playbackState;
    //        playerDirtWalk.getPlaybackState(out playbackState);
    //        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
    //        {
    //            Debug.Log("WalkSoundPLay");
    //            playerDirtWalk.start();
    //        }
    //    }
    //    else
    //    {
    //        playerDirtWalk.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);




    //        //if (WSFXObject == null)
    //        //{
    //        //   // WalkSFXManager.instance.PlaySFX(Random.Range(1, 4));
    //        //    //Debug.Log("playing walk");
    //        //}
    //    }
        
    //}

    void FixedUpdate()
    {
        MovePlayer();
        UpdateSound();
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
            //if 
            playerModel.localScale = new UnityEngine.Vector3(playerModel.localScale.x, crouchYScale, playerModel.localScale.z);
            rb.AddForce(UnityEngine.Vector3.down * 5f, ForceMode.Impulse);
            isCrouching = true;
        }

        //not crouching 
        if (Input.GetKeyUp(crouchKey))
        {
            playerModel.localScale = new UnityEngine.Vector3(playerModel.localScale.x, startYScale, playerModel.localScale.z);
            rb.AddForce(UnityEngine.Vector3.up * 3f, ForceMode.Impulse);
            isCrouching = false;
        }
    }

    private void StateHandler()
    {

        //"Ride like the wind" - Christopher Cross 
        // RUNNING
        if (grounded && Input.GetKey(sprintKey) && staminaDuration > 0)
        {
            state = MovementState.sprinting;
            headBobScript.frequency = 14;
            camera.fieldOfView = Mathf.Lerp(60,63, Mathf.SmoothStep(0,1,1));
            moveSpeed = sprintSpeed;
            staminaDuration -= Time.deltaTime;
        }

        //"Walk it like I talk it" - Migos 
        // WALKING
        else if (grounded && !isCrouching && !inputNotActive)
        {
            if (iswalking)
            {
                state = MovementState.walking;
                moveSpeed = walkSpeed;
                headBobScript.frequency = 10;
                camera.fieldOfView = Mathf.Lerp(60, 63, Mathf.SmoothStep(0, 1, 0));
                if (staminaDuration < 4)
                {
                    staminaDuration += Time.deltaTime;
                }
            }
        }

        //I cant come up with a song for short people
        //CROUCHING
        else if (grounded && isCrouching)
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
            camera.fieldOfView = Mathf.Lerp(60, 63, Mathf.SmoothStep(0, 1, 0));
            headBobScript.frequency = 8;
            if (staminaDuration < 4)
            {
                staminaDuration += Time.deltaTime;
            }
        }

        else if (grounded && inputNotActive)
        {
            state = MovementState.idling;
            moveSpeed = idleSpeed;
            camera.fieldOfView = Mathf.Lerp(60, 63, Mathf.SmoothStep(0, 1, 0));
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
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        }


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
    private void UpdateSound()
    {
        if (iswalking && grounded)
        {
            //Debug.Log("WalkSoundPlay");
            PLAYBACK_STATE playbackState;
            playerDirtWalk.getPlaybackState(out playbackState);
            if (playbackState == PLAYBACK_STATE.STOPPED)
            {
                playerDirtWalk.start();
                //playerDirtWalk.release();
            }
        }
        else if (!iswalking)
        {
            playerDirtWalk.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
   