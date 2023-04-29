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

    // When Player collect the item
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && item.isCollectable)
        {
            if (item.isAutoConsume) {
                FindObjectOfType<AbilityManager>().ApplyAbility(item);
                item.PlayCharEffect();
            } else {
                inventory.AddItem(item);
            }
            if (item.collectSound != null)
                item.PlayContactSound();
            Destroy(gameObject);
        }
    }
}
