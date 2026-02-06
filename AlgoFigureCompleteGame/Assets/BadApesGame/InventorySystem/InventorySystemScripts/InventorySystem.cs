using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem instance;

    public Dictionary<InventoryItemData, InventoryItem> inventoryDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public UnityAction<InventorySystem> onInventoryChanged;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        onInventoryChanged?.Invoke(this);
    }

    public void AddToInventory(InventoryItemData _itemData)
    {
        if(inventoryDictionary.TryGetValue(_itemData , out InventoryItem inventoryItemOut))
        {
            inventoryItemOut.AddToStack();
            onInventoryChanged?.Invoke(this);
        }
        else
        {
            InventoryItem newInventoryItem = new InventoryItem(_itemData);
            inventory.Add(newInventoryItem);
            inventoryDictionary.Add(_itemData, newInventoryItem);
            onInventoryChanged?.Invoke(this);
        }
    }

    public void RemoveItemFromInventory(InventoryItemData _itemData)
    {
        if(inventoryDictionary.TryGetValue(_itemData ,out InventoryItem inventoryItemOut))
        {
            inventoryItemOut.RemoveFromStack();
            onInventoryChanged?.Invoke(this);
            if (inventoryItemOut.stackSize <= 0)
            {
                inventory.Remove(inventoryItemOut);
                inventoryDictionary.Remove(_itemData);
                onInventoryChanged?.Invoke(this);
            }
        }
    }

    public bool HasItem(InventoryItemData _itemToCheck)
    {
        if(inventoryDictionary.TryGetValue(_itemToCheck , out InventoryItem inventoryItemSlotOut) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
