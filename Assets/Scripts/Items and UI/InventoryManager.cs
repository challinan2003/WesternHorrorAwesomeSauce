using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryInterface;
    public static InventoryManager current;
    private bool menuActivated;
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory {get; private set;}

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
            Awake();
        }
    }
    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
    
    
    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    [System.Serializable]
        public class InventoryItem //item data and stack size 
        {
            
            public InventoryItemData data {get; private set;}
            public int stackSize {get; private set;}

            //contructor that passes and sets inventory data
            public InventoryItem(InventoryItemData source)
            {
                data = source;
                AddToStack();
            }

            //add to stack
            public void AddToStack()
            {
                stackSize++;
            }   
            //remove from stack
            public void RemoveFromStack()
            {
                stackSize--;
            }
        }
    public void Add(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }

}

