using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    void Update()
    {
        if (item.tag == "Item" && Input.GetButtonDown("Interact"))
        {
            item.OnHandlePickupItem();
        }
    }
}