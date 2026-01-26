using UnityEngine;

public class Item : MonoBehaviour
{
    public int pickupSFX = 0;
    public InventoryManager inventoryManager;
    //public InventoryItemData referenceItem;

    //void Start()
    //{
        //inventoryManager = FindAnyObjectByType<InventoryManager>();
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (tag == "Item" && Input.GetButtonDown("Interact") && collision.gameObject.tag == "Player")
        {
            //OnHandlePickupItem();
        }
    }

    //public void OnHandlePickupItem()
    //{
            //InventoryManager.current.Add(referenceItem);
            //Destroy(gameObject);
           // SoundManager.instance.PlaySFX(pickupSFX);
    //}
}