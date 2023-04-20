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

        // Ability check when used
        switch (Item.ability){
            case Abilities.MultiplyCharRunSpeed_110Per:
                AbilityManager.instance.MultiplyCharRunSpeed(1.05f);
                break;
            case Abilities.MultiplyStepSpeed_110Per:
                AbilityManager.instance.MultiplyStepSpeed(1.05f);
                break;
            case Abilities.InstantSpawn_1Step:
                AbilityManager.instance.InstantSpawn1Step();
                break;
            case Abilities.HPHeal_Plus1:
                AbilityManager.instance.HPHealPlus1();
                break;
        }
    }

    // Clear slot when all items on that slot are used up
    void RemoveItem(){
        Destroy(gameObject);
    }

    public void PlaySound(){
        FindObjectOfType<AudioManager>().Play("");
    }
}
