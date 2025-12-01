using UnityEngine;

public class Drunk : MonoBehaviour
{
    public float drunkenness;
    public bool isDrunk = false;
    public GunSystem gunsystem;
    public Madness madness;
    public InventoryManager inventory;
    public float drunkTimer = 0.0f;

    //getting drunk
    public void Update()
    {
        ConsumeAlc();
    }
    public void ConsumeAlc()
    {
        //once inventory is reworked, this function will check inventory for alcohol
        if (Input.GetKeyDown(KeyCode.V))
        {
            madness.madbuildup -= 400;
            drunkenness += 25;
            drunkenness = Mathf.Clamp(drunkenness, 0, 100);

            Debug.Log("Drinking ALCOHOL!!!!");
        }
    }

    //being drunk
    public void drunk()
    {
        if (drunkenness == 100)
        {
            isDrunk = true;
            gunsystem.reloadTime = 5;
            drunkenness -= 0.5f;
        }
    }
    
    public void drunkDeath()
    {
        if (isDrunk == true)
        {
            drunkTimer = 60.0f;
            drunkTimer -= Time.deltaTime;
        }
    }
}