using UnityEngine;

public class Drunk : MonoBehaviour
{
    public float drunkenness;
    public bool isDrunk = false;
    public GunSystem gunsystem;
    public Madness Madness;
    public InventoryManager InventoryManager;
    public float drunkTimer = 0.0f;
    public Material madnessMat;
    public Material drunkMat;

    //getting drunk
    public void Update()
    {
        print(drunkenness);
        ConsumeAlc();
        drunk();
        
        //natural drunk decay
        if (drunkenness > 0.0f && Time.deltaTime > 0)
        {
            drunkenness -= 0.001f;
        }
    }
    public void ConsumeAlc()
    {
        //once inventory is reworked, this function will check inventory for alcohol
        if (Input.GetKeyDown(KeyCode.V) && InventoryManager.alcoholCount > 0)
        {
            AudioManager.instance.PlayOneshot(FMODEvents.instance.PlayerDrink, this.transform.position);
            InventoryManager.alcoholCount -= 1;
            Madness.madBuildup -= 400.0f;
            madnessMat.SetFloat("_Opacity", 0.01f);
            madnessMat.SetFloat("_Intensity", 10f);
            drunkenness += 25;
            drunkenness = Mathf.Clamp(drunkenness, 0, 100);

            //madness resist
            Madness.isMad = false;
            Madness.madResist = true;
            Madness.madResistTimer = 15.0f;
            
            

            Debug.Log("Drinking ALCOHOL!!!!");
        }
    }
    public void madnessResistEnd()
    {
        if (Madness.madResistTimer <= 0.0f)
        {
            Madness.madResist = false;
            Madness.madResistTimer = 0.0f;
        }
    }

    //being drunk
    public void drunk()
    {
        //set up VFX
        if (drunkenness < 50)
        {
            drunkMat.SetFloat("_Blend", 0.00f);
        }
        if (drunkenness >= 50)
        {
            drunkMat.SetFloat("_Blend", 0.03f);
        }

        if (drunkenness >= 75)
        {
            drunkMat.SetFloat("_Blend", 0.06f);
        }

        if (drunkenness == 100)
        {
            isDrunk = true;
            gunsystem.reloadTime = 5;
            drunkTimer = 30.0f;
            drunkMat.SetFloat("_Blend", 0.12f);
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