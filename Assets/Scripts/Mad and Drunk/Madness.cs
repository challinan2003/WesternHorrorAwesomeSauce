using NUnit.Framework;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Madness : MonoBehaviour
{
    public float madbuildup;
    public bool IsMad;

    //other game objects
    public GunSystem gunsystem;
    public PlayerMovement pmovement;
    public Drunk drunk;
    public int MadnessSFX = 0;
    public SoundManager soundManager;
    public GameObject SFXObject;

    //madness death timer
    public float madnessTimer = 60.0f;

    void Start()
    {
        madbuildup = 0;
    }
    // Update is called once per frame
    void Update()
    {
        SFXObject = GameObject.Find("SFXOneShotPrefab_Madness");
        CheckForMadness();

        drunk.ConsumeAlc();
        {
            //!IsMad;
        }
    }

    void FixedUpdate()
    {
        if (!IsMad)
        {
            MadBuildup(1);
        }
    }

    public void CheckForMadness()
    {
        if (IsMad)
        {
            EnterMadness();
        }
    }

    public void MadBuildup(int mad)
    {
        if (madbuildup < 1000)
        {
            madbuildup += mad;
        }
        // clamp to [0,100] using Unity's Mathf
        madbuildup = Mathf.Clamp(madbuildup, 0, 1000);

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
        if (SFXObject == null)
        {
            SoundManager.instance.PlaySFX(MadnessSFX); // Play madness sound effect
        }
        IsMad = true;
        if (gunsystem != null)
        {
            gunsystem.damage = 15;
            gunsystem.reloadTime = 2;
        }

        if (pmovement != null)
        {
            pmovement.walkSpeed = 6;
            pmovement.crouchSpeed = 4;
            pmovement.sprintSpeed = 7;
        }
    }

    public void MadnessDeath()
    {
        if (IsMad)
        {
            madnessTimer -= Time.deltaTime;

            if (madnessTimer <= 0.0f)
            {
                //YOU SUCCUMBED TO MADNESS!!!!!!!!!!!
            }
            
        }
    }
}
