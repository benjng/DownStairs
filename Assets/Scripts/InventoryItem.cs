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
        Debug.Log("Use this item with ability: " + Item.ability);
        // Deduct 1 from item slot
        ItemQty--;

        // Ability check when used
        switch (Item.ability){
            case ItemData.Abilities.MultiplyCharRunSpeed_110Per:
                AbilityManager.instance.MultiplyCharRunSpeed(1.05f);
                break;
            case ItemData.Abilities.MultiplyStepSpeed_110Per:
                AbilityManager.instance.MultiplyStepSpeed(1.05f);
                break;
            case ItemData.Abilities.InstantSpawn_1Step:
                AbilityManager.instance.InstantSpawn1Step();
                break;
        }
    }

    // Clear slot when all items on that slot are used up
    private void RemoveItem(){
        Destroy(gameObject);
    }
}
