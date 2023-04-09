using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestInventoryUI
{
    private InventoryUI inventoryUI;
    private ItemData testItem;
    private InventoryItem[] layoutItems;

    [SetUp]
    public void Setup(){
        // inventoryUI = new GameObject().AddComponent<InventoryUI>();
        // testItem = ScriptableObject.CreateInstance<ItemData>();
        // testItem.name = "A Test Item";
        // inventoryUI.itemsLayouts = new Transform[]{new Transform(), new Transform()};
    }
    
    [Test]
    public void Test_Update_UI()
    {
        // Arrange

        // Act
        inventoryUI.UpdateUI(testItem);

        // Assert
    }
}
