using UnityEngine;

public class Drunk : MonoBehaviour
{
    public float drunkenness;
    public bool isDrunk = false;
    public GunSystem gunsystem;
    public Madness madness;
    public InventoryManager inventory;
    public float drunkTimer = 0.0f;
    public Material madnessMat;

    //getting drunk
    public void Update()
    {
        ConsumeAlc();
        drunk();
        
        //natural drunk decay
        if (drunkenness > 0.0f && Time.deltaTime > 0)
        {
            drunkenness -= 0.05f;
        }
    }
    public void ConsumeAlc()
    {
        //once inventory is reworked, this function will check inventory for alcohol
        if (Input.GetKeyDown(KeyCode.V) && inventory.alcoholCount > 0)
        {
            AudioManager.instance.PlayOneshot(FMODEvents.instance.PlayerDrink, this.transform.position);
            inventory.alcoholCount -= 1;
            madness.madBuildup -= 400.0f;
            madness.vignetteTargetValue += 4.0f;
            madness.opacityTargetValue -= 0.4f;
            drunkenness += 25;
            drunkenness = Mathf.Clamp(drunkenness, 0, 100);

            //madness resist
            madness.isMad = false;
            madness.madResist = true;
            madness.madResistTimer = 15.0f;
            
            

            Debug.Log("Drinking ALCOHOL!!!!");
        }
    }
    public void madnessResistEnd()
    {
        if (madness.madResistTimer <= 0.0f)
        {
            madness.madResist = false;
            madness.madResistTimer = 0.0f;
        }
    }

    //being drunk
    public void drunk()
    {
        if (drunkenness == 100)
        {
            isDrunk = true;
            gunsystem.reloadTime = 5;
            drunkTimer = 30.0f;
        }

        if (isDrunk)
        {
            drunkTimer -= Time.deltaTime;
            if (drunkTimer <= 0.0f)
            {
                isDrunk = false;
                gunsystem.reloadTime = 2;
                drunkenness = 0.0f;
            }
        }
    }
    
    //public void drunkDeath()
    //{
        //if (isDrunk == true)
        //{
            //drunkTimer = 60.0f;
            //drunkTimer -= Time.deltaTime;
       // }
   // }
}