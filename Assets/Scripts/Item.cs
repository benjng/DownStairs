using UnityEngine;

// In game item gameObject
public class Item : MonoBehaviour, ICollectable
{
    public ItemData item;
    private Inventory inventory;

    void Start() { 
        inventory = Inventory.instance;
        // ability.OnInventoryChanged += Check;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && item.isCollectable)
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
