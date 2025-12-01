using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryInterface;
    private bool menuActivated;
    public InventoryItemData data {get; private set;}
    public int stackSize {get; private set;}

    private void Awake()
    {
        //InventoryInterface = new List<InventoryItem>();
        //m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
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