using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public TextMeshProUGUI itemnameText;
    public TextMeshProUGUI itemAmountText;
    public Image itemIcon;

    public void SetupSlot(InventoryItem _inventoryItem)
    {
        itemIcon.sprite = _inventoryItem.itemData.icon;
        itemnameText.text = _inventoryItem.itemData.displayName;
        itemAmountText.text = "x" + _inventoryItem.stackSize.ToString();
    }
}
