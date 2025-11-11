using UnityEngine;

public class Item : MonoBehaviour
{
    public int pickupSFX = 0;
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            inventoryManager.AddItem(itemName, quantity, sprite);
           
            Destroy(gameObject);
            SoundManager.instance.PlaySFX(pickupSFX);
        }
    }
}
