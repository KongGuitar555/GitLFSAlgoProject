using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{

    public static InventoryToggle instance;

    public GameObject inventoryUIPanel;

    public bool inventoryOpen;


    private void Awake()
    {
        instance = this;
    }

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

        LockAndHideCursor();
    }

    public void OpenInventoryPanel()
    {
        inventoryUIPanel.SetActive(true);
        InventorySystem.instance.onInventoryChanged?.Invoke(InventorySystem.instance);
        inventoryOpen = true;

        UnlockandShowCursor();

    }

    public void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockandShowCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
