using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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
    private bool staminaRecharge;
    private float rechargeTimer;
    private bool isCrouching = false;
    //private EventInstance playerDirtWalk;

    public bool iswalking = false;
    public bool isidle = false;
    public bool inputNotActive = false;


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

    public enum Current_Terrain {Dirt, Wood, Metal}
    [SerializeField]
    private Current_Terrain currentTerrain;
    private string StepEvent = "event:/Playersteps";
    //private int terrain;

    private EventInstance PlayerFootSteps;
    float timer = 0.0f;
    [SerializeField]
    float footstepSpeed = 0.75f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

        startYScale = transform.localScale.y;
        //playerDirtWalk = AudioManager.instance.CreateEventInstance(FMODEvents.instance.DirtWalk);
        //playerDirtWalk.set3DAttributes(RuntimeUtils.To3DAttributes(playerModel.gameObject));
    }


    private void DetermineTerrain()
    {
        RaycastHit[] hit;
        hit = Physics.RaycastAll(transform.position, UnityEngine.Vector3.down, 10.0f);
        foreach (RaycastHit rayhit in hit)
        {
            if(rayhit.collider.tag == "Dirt")
            {
                //Debug.Log("dirt");
                currentTerrain = Current_Terrain.Dirt;
            }
            else if (rayhit.collider.tag == "Wood")
            {
                currentTerrain = Current_Terrain.Wood;
            }
            else if (rayhit.collider.tag == "Metal")
            {
                currentTerrain = Current_Terrain.Metal;
            }
        }


    }


    public void SelectAndPlay()
    {
        switch (currentTerrain) 
        { 
        case Current_Terrain.Dirt:
                if (iswalking && state == MovementState.walking)
                {
                    PlayWalkSteps(0);
                }
                else if (iswalking && state == MovementState.sprinting)
                {
                    PlayRunSteps(0);
                }
                break;
        
        case Current_Terrain.Wood:
                if (iswalking && state == MovementState.walking)
                {
                    PlayWalkSteps(1);
                }
                else if (iswalking && state == MovementState.sprinting)
                {
                    PlayRunSteps(1);
                }
                break;
        case Current_Terrain.Metal:
                if (iswalking && state == MovementState.walking)
                {
                    PlayWalkSteps(2);
                }
                else if (iswalking && state == MovementState.sprinting)
                {
                    PlayRunSteps(2);
                }
                break;

        }
    }

    private void PlayWalkSteps(int terrain)
    {
        //DetermineTerrain();
        EventInstance Walk = RuntimeManager.CreateInstance(StepEvent);
        Walk.setParameterByName("Terrain", terrain,false);
        Walk.setParameterByName("WalkRun", 0, false);
        Walk.set3DAttributes(RuntimeUtils.To3DAttributes(playerModel.gameObject));
        Walk.start();
        Walk.release();
    }
    private void PlayRunSteps(int terrain)
    {
        //DetermineTerrain();
        EventInstance Run = RuntimeManager.CreateInstance(StepEvent);
        Run.setParameterByName("Terrain", terrain ,false);
        Run.setParameterByName("WalkRun", 1, false);
        Run.set3DAttributes(RuntimeUtils.To3DAttributes(playerModel.gameObject));
        Run.start();
        Run.release();
    }
    void Update()
    {
        //WSFXObject = GameObject.Find("WalkSFXOneShotPrefab(Clone)");
        //check if player is grounded 
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        TrackInput();
        SpeedControl();
        StateHandler();
        PlayStep();

        //handle drag
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        if (staminaDuration <= 0)
        {
            staminaDuration = 0;
            staminaRecharge = false;
        }

        if (rechargeTimer >= -4)
        {
            rechargeTimer -= Time.deltaTime;
        }

        if (staminaDuration >= 4)
        {
            staminaDuration = 4;
        }

        if (staminaRecharge == false && rechargeTimer <= -4)
        {
            rechargeTimer = 0;
            staminaRecharge = true;
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


    void FixedUpdate()
    {
        MovePlayer();
        //UpdateSound();
    }
    private void PlayStep()
    {
        DetermineTerrain();
        if (iswalking && grounded)
        {
            if (timer > footstepSpeed)
            {
                SelectAndPlay();
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
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
        if (grounded && Input.GetKey(sprintKey) && staminaDuration > 0 && staminaRecharge)
        {
            state = MovementState.sprinting;
            headBobScript.frequency = 14;
            camera.fieldOfView = Mathf.SmoothStep(60,63,1);
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
                camera.fieldOfView = Mathf.SmoothStep(63, 60, 1);
                if (staminaDuration < 4)
                {
                    staminaDuration += Time.deltaTime;
                }
            }
        }

        //I cant come up with a song for short people (joshua edit: shorty a little baddie (shorty got the fatty (shorty got the fatty)))
        //CROUCHING
        else if (grounded && isCrouching)
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
            camera.fieldOfView = Mathf.SmoothStep(63, 60, 1);
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
            camera.fieldOfView = Mathf.SmoothStep(63, 60, 1);
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
    //private void UpdateSound()
    //{
    //    if (!isidle && grounded)
    //    {
    //        //Debug.Log("WalkSoundPlay");
    //        PLAYBACK_STATE playbackState;
    //        FootSteps.getPlaybackState(out playbackState);
    //        if (playbackState == PLAYBACK_STATE.STOPPED)
    //        {
    //            FootSteps.start();
    //            //playerDirtWalk.release();
    //        }
    //    }
    //    else if (isidle)
    //    {
    //        FootSteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //    }
    //     private void UpdateSound()
    //{
    //    if (iswalking && grounded)
    //    {
    //        //Debug.Log("WalkSoundPlay");
    //        PLAYBACK_STATE playbackState;
    //        playerDirtWalk.getPlaybackState(out playbackState);
    //        if (playbackState == PLAYBACK_STATE.STOPPED)
    //        {
    //            playerDirtWalk.start();
    //            //playerDirtWalk.release();
    //        }
    //    }
    //    else if (!iswalking)
    //    {
    //        playerDirtWalk.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //    }
    }
