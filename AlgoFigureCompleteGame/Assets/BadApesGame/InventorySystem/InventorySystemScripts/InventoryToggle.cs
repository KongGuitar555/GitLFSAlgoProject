using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUIPanel;

    public bool inventoryOpen;

    private void Start()
    {
        CloseInventoryPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryOpen == true)
            {
                CloseInventoryPanel();
            }
            else
            {
                OpenInventoryPanel();
            }
        }
    }

    public void CloseInventoryPanel()
    {
        inventoryUIPanel.SetActive(false);
        inventoryOpen = false;
    }

    public void OpenInventoryPanel()
    {
        inventoryUIPanel.SetActive(true);
        InventorySystem.instance.onInventoryChanged?.Invoke(InventorySystem.instance);
        inventoryOpen = true;

    }
}
