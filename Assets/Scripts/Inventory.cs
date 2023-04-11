using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    // Only One single list in game
    public static Inventory instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicated Inventory instance found.");
            return;
        }
        instance = this; // Create the unique instance of inventory
    }
    #endregion

    // public delegate void InventoryChangedEventHandler();
    // public event InventoryChangedEventHandler OnInventoryChanged;

    public InventoryUI InventoryUI { get; set; }
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public Dictionary<string, int> Items { get => items; set => items = value; }

    public void AddItem(ItemData item)
    {
        if (items.ContainsKey(item.name)){
            items[item.name]++;
        } else {
            items.Add(item.name, 1);
            // Debug.Log("Added new Inventory: " + item.name.ToString());
        }
        // OnInventoryChanged?.Invoke(); // Inform there is a change in inventory list, so inventoryUI can update
        InventoryUI.UpdateUI(item); // Update UI
    }

    public void RemoveItem()
    {
        // When time, remove the Inventory
    }
}
