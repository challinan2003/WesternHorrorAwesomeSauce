using NUnit.Framework;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Madness : MonoBehaviour
{
    //madness specific variables
    public float madBuildup;
    public bool isMad;
    public bool madResist;
    

    //other game objects
    public GunSystem gunSystem;
    public PlayerMovement pMovement;
    public Drunk drunk;
    public int madnessSFX = 0;
    public SoundManager soundManager;
    public GameObject SFXObject;
    public  GameObject Death;

    //timers
    public float madnessTimer = 60.0f;
    public float madResistTimer = 0.0f;

    void Start()
    {
        madBuildup = 0;
        madResist = false;
    }
    // Update is called once per frame
    void Update()
    {
        SFXObject = GameObject.Find("SFXOneShotPrefab(Clone)");
        checkForMadness();

        //madness death timer
        if (isMad)
        { 
            madnessTimer -= Time.deltaTime;
        }
        if (madnessTimer <= 0.0f)
        {
            Death.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("You succumbed to madness.");
            madnessTimer = 0.0f;
        }

        if (madResist)
        {
            madResistTimer = Mathf.Clamp(madResistTimer, 0, 15);
            madResistTimer -= Time.deltaTime;
        }
    }

    //constant madness buildup
    void FixedUpdate()
    {
        if (!isMad && !madResist)
        {
            madnessBuildup(1.0f);
        }
        else if (madResist == true)
        {
            madnessBuildup(0.1f);
        }
    }


    public void checkForMadness()
    {
        if (isMad)
        {
            enterMadness();
        }
    }


    public void madnessBuildup(float mad)
    {
        if (madBuildup < 1000.0f)
        {
            madnessTimer = 60.0f;
            madBuildup += mad;
        }
        // clamp to [0,1000] to ensure it doesn't exceed bounds
        madBuildup = Mathf.Clamp(madBuildup, 0.0f, 1000.0f);

        if (madBuildup == 1000 && !isMad)
        {
            isMad = true;
        }
        else
        {
            isMad = false;
        }

    }

    public void enterMadness() // renamed method
    {
        
        isMad = true;
        
        //madness effects
        if (isMad)
        {
            gunSystem.damage = 15;
            gunSystem.reloadTime = 3;

            pMovement.walkSpeed = 4;
            pMovement.crouchSpeed = 3;
            pMovement.sprintSpeed = 5;
            if (SFXObject == null)
            SoundManager.instance.PlaySFX(madnessSFX); // Play madness sound effect
            Debug.Log("Playing madness SFX");
        }
        else
        {
            gunSystem.damage = 10;
            gunSystem.reloadTime = 2;

            pMovement.walkSpeed = 2.5f;
            pMovement.crouchSpeed = 2;
            pMovement.sprintSpeed = 4;
        }
    }
}
