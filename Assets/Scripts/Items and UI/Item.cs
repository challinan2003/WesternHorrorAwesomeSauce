using UnityEngine;

public class Item : MonoBehaviour
{
    public int pickupSFX = 0;
    public InventoryManager inventoryManager;
    public InventoryItemData referenceItem;

    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void OnHandlePickupItem()
    {
            InventoryManager.current.Add(referenceItem);
            Destroy(gameObject);
            SoundManager.instance.PlaySFX(pickupSFX);
    }
}