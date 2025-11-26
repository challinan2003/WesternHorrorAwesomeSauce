using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Madness : MonoBehaviour
{
    public float madbuildup;
    public bool IsMad;

    //other game objects
    public GunSystem gunsystem;
    public PlayerMovement pmovement;

    //madness death timer
    public float madnessTimer = 0.0f;

    void Start()
    {
        madbuildup = 0;
    }
    // Update is called once per frame
    void Update()
    {
        CheckForMadness();
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
            EnterMadness();
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
        IsMad = true;
        if (gunsystem != null)
        {
            gunsystem.damage = 15;
            gunsystem.reloadTime = 2;
        }

        if (pmovement != null)
        {
            pmovement.walkSpeed = 9;
            pmovement.crouchSpeed = 7;
            pmovement.sprintSpeed = 12;
        }
    }

    public void MadnessDeath()
    {
        if (IsMad)
        {
            madnessTimer = 60.0f;
            madnessTimer -= Time.deltaTime;

            if (madnessTimer <= 0.0f)
            {
                //YOU SUCCUMBED TO MADNESS!!!!!!!!!!!
            }
            
        }
    }
}
