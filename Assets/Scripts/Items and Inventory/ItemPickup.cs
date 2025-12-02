using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public SoundManager soundManager;
    public int pickupSFX = 0;
    public void OnHandlePickupItem()
    {
        InventoryManager.current.Add(referenceItem);
        Destroy(gameObject);
        SoundManager.instance.PlaySFX(pickupSFX);
    }

    //item pickup input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            OnHandlePickupItem();
        }
    }
}
