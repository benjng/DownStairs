using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform[] itemsLayouts;
    
    [SerializeField] private InventoryItem newItem; // for Instantiate 
    private Inventory inventory;
    private InventoryItem[] layoutItems;
    void Start()
    {
        inventory = Inventory.instance;
        // inventory.OnInventoryChanged += UpdateUI;
    }

    // Called when inventory has changes (item added, removed etc)
    public virtual void UpdateUI(ItemData item){
        foreach (var layout in itemsLayouts){
            layoutItems = layout.GetComponentsInChildren<InventoryItem>();
            foreach (InventoryItem layoutItem in layoutItems){
                // if found existing item, do not add new item to slots
                if (layoutItem.name == item.name) {
                    layoutItem.itemQty++;
                    return;
                } 
            }
        }
        
        // Choose layout
        Transform layoutToParent;
        if (item.isUsable){
            layoutToParent = itemsLayouts[0]; // Right panel
        } else {
            layoutToParent = itemsLayouts[1]; // Light panel
        }
        // Add new item to slots
        InventoryItem thisItem = Instantiate(newItem, layoutToParent);
        thisItem.item = item;
    }
}

public class InventoryUIStub : InventoryUI
{
    public override void UpdateUI(ItemData item)
    {
        // do nothing, ignore the call to UpdateUI()
    }
}