using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem 
{
    public InventoryItemData itemData;
    public int stackSize;

    public InventoryItem(InventoryItemData _itemData)
    {
        this.itemData = _itemData;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
