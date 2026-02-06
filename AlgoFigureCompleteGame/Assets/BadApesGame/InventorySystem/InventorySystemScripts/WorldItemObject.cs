using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemObject : MonoBehaviour
{
    public InventoryItemData itemData;


    private void OnMouseDown()
    {
        if (itemData != null)
        {
            InventorySystem.instance.AddToInventory(itemData);
            Destroy(gameObject);
        }
    }
}
