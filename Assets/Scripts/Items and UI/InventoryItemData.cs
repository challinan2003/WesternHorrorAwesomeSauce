using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "Scriptable Objects/InventoryItemData")]
public class InventoryItemData : ScriptableObject
{
    public int pickupSFX = 0;
    public string itemName;
    public string itemID;
    public int itemAmnt;
}
