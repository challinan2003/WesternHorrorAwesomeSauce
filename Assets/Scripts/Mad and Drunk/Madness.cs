using NUnit.Framework;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Madness : MonoBehaviour
{
    //madness specific variables
    public float madbuildup;
    public bool IsMad;
    public bool madResist;
    

    //other game objects
    public GunSystem gunsystem;
    public PlayerMovement pmovement;
    public Drunk drunk;
    public int MadnessSFX = 0;
    public SoundManager soundManager;
    public GameObject SFXObject;
    public  GameObject Death;

    //timers
    public float madnessTimer = 60.0f;
    public float madResistTimer = 0.0f;

    void Start()
    {
        madbuildup = 0;
        madResist = false;
    }
    // Update is called once per frame
    void Update()
    {
        SFXObject = GameObject.Find("SFXOneShotPrefab(Clone)");
        CheckForMadness();

        //madness death timer
        if (IsMad)
        { 
            madnessTimer -= Time.deltaTime;
        }
        if (madnessTimer < 0.0f)
        {
            Death.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("PLEEEEEEEEEAAAAAAASE");
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
        if (!IsMad && !madResist)
        {
            MadBuildup(1.0f);
        }
        else if (madResist == true)
        {
            MadBuildup(0.1f);
        }
    }


    public void CheckForMadness()
    {
        if (IsMad)
        {
            EnterMadness();
        }
    }


    public void MadBuildup(float mad)
    {
        if (madbuildup < 1000.0f)
        {
            madnessTimer = 60.0f;
            madbuildup += mad;
        }
        // clamp to [0,1000] to ensure it doesn't exceed bounds
        madbuildup = Mathf.Clamp(madbuildup, 0.0f, 1000.0f);

        if (madbuildup == 1000 && !IsMad)
        {
            IsMad = true;
        }
        else
        {
            IsMad = false;
        }

    }

    public void EnterMadness() // renamed method
    {
        
        IsMad = true;
        
        //madness effects
        if (IsMad)
        {
            gunsystem.damage = 5;
            gunsystem.reloadTime = 10;

            pmovement.walkSpeed = 3;
            pmovement.crouchSpeed = 2;
            pmovement.sprintSpeed = 4;
            if (SFXObject == null)
        {
            SoundManager.instance.PlaySFX(MadnessSFX); // Play madness sound effect
            Debug.Log("playing audio please god");
        }
        }
        else
        {
            gunsystem.damage = 25;
            gunsystem.reloadTime = 2;

            pmovement.walkSpeed = 5;
            pmovement.crouchSpeed = 3;
            pmovement.sprintSpeed = 7;
        }
    }
}
