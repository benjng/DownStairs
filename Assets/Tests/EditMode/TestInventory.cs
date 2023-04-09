using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestInventory
{
    private Inventory inventory;
    private ItemData testItem;

    [SetUp]
    public void Setup()
    {
        inventory = new GameObject().AddComponent<Inventory>();
        testItem = ScriptableObject.CreateInstance<ItemData>();
        testItem.name = "A Test Item";
        inventory.inventoryUI = new GameObject().AddComponent<InventoryUIStub>();
    }

    [Test]
    public void Test_Add_New_Item_To_Inventory()
    {
        // Arrange
        // Ensure inventory is empty before adding item
        Assert.IsEmpty(inventory.items);

        // Act
        inventory.AddItem(testItem);

        // Assert
        int expectedItemsCount = 1;
        int expectedItemQty = 1;
        Assert.AreEqual(expectedItemsCount, inventory.items.Count);
        Assert.AreEqual(expectedItemQty, inventory.items[testItem.name]);
    }

    [Test]
    public void Test_Add_Existing_Item_To_Inventory()
    {
        // Arrange
        inventory.items.Add(testItem.name, 1);

        // Make sure inventory has one item before adding item
        Assert.AreEqual(1, inventory.items.Count);

        // Act
        inventory.AddItem(testItem);

        // Assert
        int expectedItemsCount = 1;
        int expectedItemQty = 2;
        // Make sure no duplicated addition
        Assert.AreEqual(expectedItemsCount, inventory.items.Count);
        Assert.AreEqual(expectedItemQty, inventory.items[testItem.name]);
    }
}
