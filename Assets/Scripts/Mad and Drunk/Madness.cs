using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Madness : MonoBehaviour
{
    //public GameObject SFXObject;
    public int MaddnessSFX = 0;
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
   //     target = GameObject.Find ("Gun");
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
            EnterMadness(); // renamed from Madness()
    }

    public void MadBuildup(int mad)
    {
        madbuildup += mad;

        // clamp to [0,100] using Unity's Mathf
        madbuildup = Mathf.Clamp(madbuildup, 0, 1000);

        if (madbuildup == 1000 && !IsMad)
        {
            IsMad = true;
        }

    }

    public void EnterMadness() // renamed method
    {
        IsMad = true;
       // if (SFXObject == null)
         //   SoundManager.instance.PlaySFX(MaddnessSFX);
        if (gunsystem != null)
        {
            gunsystem.damage = 15;
            gunsystem.reloadTime = 2;
        }

        if (pmovement != null)
        {
            pmovement.walkSpeed = 7;
            pmovement.crouchSpeed = 5;
            pmovement.sprintSpeed = 10;
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
