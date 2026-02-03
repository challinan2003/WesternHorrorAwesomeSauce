using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryInterface;
    public static InventoryManager current;
    private bool menuActivated;

    //item counts
    public int alcoholCount = 0;
    public int cigaretteCount = 0;
    public int bulletCount = 0;

    //other game objects
    public Drunk drunk;
    public Madness madness;
    public GunSystem gunsystem;

    //UI Elements
    public TextMeshProUGUI alcoholText;
    public TextMeshProUGUI cigaretteText;

    //public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    //public List<InventoryItem> inventory {get; private set;}

    void Update() //activates and deactivates inventory menu
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
            //Awake();
        }
    }

    private void FixedUpdate() //updates item counts on UI
    {
        alcoholText.SetText("Alcohol: " + alcoholCount);
        cigaretteText.SetText("Cigarettes: " + cigaretteCount);
    }

    public void UseCigarette() //uses cigarette from inventory
    {
        if (Input.GetKeyDown(KeyCode.B) && cigaretteCount > 0)
        {
            madness.madBuildup -= 100.0f;
            cigaretteCount -= 1;
            Debug.Log("Smoking CIGARETTE!!!!");
        }
    }

    //private void Awake()
    //{
        //inventory = new List<InventoryItem>();
        //m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    //}
    
    
    //public InventoryItem Get(InventoryItemData referenceData)
    //{
        //if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        //{
            //return value;
        //}
        //return null;
    //}

    //[System.Serializable]
        //public class InventoryItem //item data and stack size 
        //{
            
            //public InventoryItemData data {get; private set;}
            //public int stackSize {get; private set;}

           // contructor that passes and sets inventory data
            //public InventoryItem(InventoryItemData source)
            //{
                //data = source;
                //AddToStack();
            //}

            //add to stack
            //public void AddToStack()
            //{
                //stackSize++;
            //}   
            //remove from stack
            //public void RemoveFromStack()
            //{
                //stackSize--;
            //}
        //}

    //public void Add(InventoryItemData referenceData)
    //{
        //if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        //{
            //value.AddToStack();
        //}
        //else
        //{
            //InventoryItem newItem = new InventoryItem(referenceData);
            //inventory.Add(newItem);
            //m_itemDictionary.Add(referenceData, newItem);
        //}
    //}

    //public void Remove(InventoryItemData referenceData)
    //{
       //if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        //{
            //value.RemoveFromStack();
            //if(value.stackSize == 0)
            //{
                //inventory.Remove(value);
                //m_itemDictionary.Remove(referenceData);
            //}
        //}
    //}
}

