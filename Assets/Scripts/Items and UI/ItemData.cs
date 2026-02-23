using System;
using UnityEngine;
using TMPro;

public class ItemData : MonoBehaviour
{
    //Item specific variables
    public string itemName;
    public int quantity;
    //public int pickupSFX = 0;

    //other game objects
    public InventoryManager InventoryManager;
    public GameObject InventoryInterface;
    public TextMeshProUGUI alcoholText;
    //public SoundManager soundManager;

    private void OnCollisionStay(Collision collision)
    {
        if (CompareTag("Gin") && collision.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            InventoryManager.alcoholCount += 1;
            alcoholText.SetText("Alcohol: " + InventoryManager.alcoholCount);
            Destroy(gameObject);
            Debug.Log("Picked up ALCOHOL");
            AudioManager.instance.PlayOneshot(FMODEvents.instance.ItemPickup, this.transform.position);
        }

        if (CompareTag("Cigs") && collision.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            InventoryManager.cigaretteCount += 5;
            Destroy(gameObject);
            Debug.Log("Picked up CIGARETTES");
            AudioManager.instance.PlayOneshot(FMODEvents.instance.ItemPickup, this.transform.position);
        }

        if (CompareTag("Bullets") && collision.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            InventoryManager.bulletCount += 6;
            Destroy(gameObject);
            Debug.Log("Picked up BULLETS");
            AudioManager.instance.PlayOneshot(FMODEvents.instance.ItemPickup, this.transform.position);
        }
    }
}