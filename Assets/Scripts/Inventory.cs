using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicated Inventory instance found.");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private InventoryUI inventoryUI;
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public Dictionary<string, int> Items { get => items; set => items = value; }
    public InventoryUI InventoryUI { get => inventoryUI; set => inventoryUI = value; }
    private int currentCoinCount = 0;

    public void AddItem(ItemData item)
    {
        UpdatePlayerCoinCount(item);
        if (items.ContainsKey(item.name)){
            items[item.name]++; // Add 1 to existing item
        } else {
            items.Add(item.name, 1); // Add new item to player inventory
        }
        inventoryUI.UpdateUI(item);
    }

    public void SubtractItem(ItemData item){
        if (items.ContainsKey(item.name)){
            items[item.name]--;
            // Debug.Log("Item "+ item.name+ " subtracted. Current value: " + items[item.name]);
            if (items[item.name] <= 0) {
                RemoveItem(item);
            }
            return;
        }
        Debug.LogWarning("Item to subtract not found!");
    }

    public void RemoveItem(ItemData item)
    {
        items.Remove(item.name);
        // Debug.Log("Item "+ item.name+ " deleted.");
    }

    void UpdatePlayerCoinCount(ItemData item){
        if (item.name != "Coin") return;
        currentCoinCount = PlayerPrefs.GetInt("CurrentCoinCount" , 0);
        Debug.Log("Adding 1 coin to PlayerPrefs CurrentCoinCount");
        PlayerPrefs.SetInt("CurrentCoinCount", currentCoinCount + 1);
    }
}
