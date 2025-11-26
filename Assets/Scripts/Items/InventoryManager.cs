using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryInterface;
    private bool menuActivated;

    void Update()
    {
        //activates menu
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryInterface.SetActive(false);
            menuActivated = false;
        }

        //deactivates menu
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryInterface.SetActive(true);
            menuActivated = true;
        }
    }
}