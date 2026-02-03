using System;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    //Item specific variables
    public string itemName;
    public int quantity;
    public int pickupSFX = 0;

    //other game objects
    public InventoryManager inventoryManager;
    public SoundManager soundManager;

    private void OnCollisionStay(Collision collision)
    {
        if (CompareTag("Gin") && collision.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            inventoryManager.alcoholCount += 1;
            Destroy(gameObject);
            SoundManager.instance.PlaySFX(0);
            Debug.Log("Picked up ALCOHOL");
        }

        if (CompareTag("Cigs") && collision.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            inventoryManager.cigaretteCount += 5;
            Destroy(gameObject);
            SoundManager.instance.PlaySFX(0);
            Debug.Log("Picked up CIGARETTES");
        }

        if (CompareTag("Bullets") && collision.gameObject.CompareTag("Player") && (Input.GetKeyDown(KeyCode.E)))
        {
            inventoryManager.bulletCount += 6;
            Destroy(gameObject);
            SoundManager.instance.PlaySFX(0);
            Debug.Log("Picked up BULLETS");
        }
    }
}