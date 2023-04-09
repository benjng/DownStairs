using UnityEngine;
using TMPro;
using UnityEngine.UI;

// UI item
public class InventoryItem : MonoBehaviour
{
    public int itemQty;
    public TMP_Text amountText;
    
    [HideInInspector] public ItemData item;

    void Start(){
        gameObject.name = item.name;
        gameObject.GetComponentInChildren<Image>().sprite = item.icon;
        itemQty = 1;
        amountText = GetComponentInChildren<TMP_Text>();
        if (!item.isUsable) {
            gameObject.GetComponentInChildren<Button>().interactable = false;
        }
    }

    void Update(){
        amountText.text = itemQty.ToString();
        if (itemQty <= 0){
            RemoveItem();
        }
    }

    // Item button reference
    public void UseItem(){
        Debug.Log("Use this item with ability: " + item.ability);
        // Deduct 1 from item slot
        itemQty--;

        // Ability check when used
        switch (item.ability){
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
    public void RemoveItem(){
        Destroy(gameObject);
    }
}
