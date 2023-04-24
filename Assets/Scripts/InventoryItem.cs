using UnityEngine;
using TMPro;
using UnityEngine.UI;

// UI item
public class InventoryItem : MonoBehaviour
{
    private TMP_Text amountText;
    
    public int ItemQty { get; set; }
    public ItemData Item { get; set; }

    void Start(){ // Init UI item behaviour (sprite, qty text, button appearance/interatability)
        gameObject.name = Item.name;
        gameObject.GetComponentInChildren<Image>().sprite = Item.icon;
        ItemQty = 1;
        amountText = GetComponentInChildren<TMP_Text>();
        if (!Item.isUsable) {
            gameObject.GetComponentInChildren<Button>().interactable = false;
        }
    }

    void Update(){
        amountText.text = ItemQty.ToString();
        if (ItemQty <= 0){
            RemoveItem();
        }
    }

    // Item button reference
    public void UseItem(){
        // Deduct 1 from item slot
        ItemQty--;
        Inventory.instance.SubtractItem(Item);
        // TODO: Play use sound here

        FindObjectOfType<AbilityManager>().ApplyAbility(Item);
    }

    // Clear slot when all items on that slot are used up
    void RemoveItem(){
        Destroy(gameObject);
    }

    public void PlaySound(){
        AudioManager.instance.Play("");
    }
}
