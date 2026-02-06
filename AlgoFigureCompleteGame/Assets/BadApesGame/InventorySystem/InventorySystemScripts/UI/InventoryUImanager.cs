using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUImanager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform gridParent;

    private void Start()
    {
        InventorySystem.instance.onInventoryChanged += RefreshInventoryUI;
    }

    public void RefreshInventoryUI(InventorySystem _inventorySystem)
    {
        foreach(Transform child in gridParent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _inventorySystem.inventory.Count; i++)
        {
            GameObject slotInstance = Instantiate(slotPrefab, gridParent);
            InventorySlotUI slotUI = slotInstance.GetComponent<InventorySlotUI>();
            slotUI.SetupSlot(_inventorySystem.inventory[i]);
        }
    }
}
