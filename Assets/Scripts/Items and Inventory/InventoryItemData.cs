using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "Scriptable Objects/InventoryItemData")]
public class InventoryItemData : ScriptableObject
{
    public int pickupSFX = 0;
    public string itemName;
    //public Sprite itemIcon;
    public string itemID;
    public GameObject prefab;
    public int itemAmnt;
 

    //private void OnCollisionEnter(Collision collision)
   // {
   //     if (collision.gameObject.tag == "Player");
   //     {

            //inventoryManager.AddItem(itemName, quantity);
           
   //         Destroy(gameObject);
    //        SoundManager.instance.PlaySFX(pickupSFX);
   //     }
    
}
