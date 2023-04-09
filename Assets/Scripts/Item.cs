using UnityEngine;

// In game item gameObject
public class Item : MonoBehaviour
{
    public ItemData item;
    private Inventory inventory;

    void Start() { 
        inventory = Inventory.instance;
        // ability.OnInventoryChanged += Check;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && item.isCollectable)
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
