using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform[] itemsLayouts; // [0]: right, [1]: left
    [SerializeField] private InventoryItem newItem; // for Instantiate 
    private Transform leftLayout, rightLayout;
    private InventoryItem[] layoutItems;

    void Start()
    {
        rightLayout = itemsLayouts[0];
        leftLayout = itemsLayouts[1];
    }

    // Called when inventory has changes (item added, removed etc)
    public virtual void UpdateUI(ItemData item){
        foreach (var layout in itemsLayouts){
            layoutItems = layout.GetComponentsInChildren<InventoryItem>();
            foreach (InventoryItem layoutItem in layoutItems){
                // if found existing item, do not add new item to slots
                if (layoutItem.name == item.name) {
                    layoutItem.ItemQty++;
                    return;
                } 
            }
        }
        
        // Choose layout
        Transform layoutToParent;
        if (item.isUsable){
            layoutToParent = rightLayout;
        } else {
            layoutToParent = leftLayout;
        }
        // Add new item to slots
        InventoryItem thisItem = Instantiate(newItem, layoutToParent);
        thisItem.Item = item;
    }
}

public class InventoryUIStub : InventoryUI
{
    public override void UpdateUI(ItemData item)
    {
        // do nothing, ignore the call to UpdateUI()
    }
}