using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateKeeper : MonoBehaviour , INPCQuestable
{
    public bool questCompleted;

    public NPCDialogueSO npcDialogueSO;

    public InventoryItemData[] requiredItem;

    InventorySystem inventorySystem;

    bool playerHasItem;

    public static UnityAction OnQuestCompleted;

    public static UnityAction<NPCDialogueSO , INPCQuestable> OnDynamicDialogueRequested;

    private void Awake()
    {
        questCompleted = false;
    }

    private void Start()
    {
        inventorySystem = InventorySystem.instance;
        playerHasItem = false;
    }

    private void OnMouseDown()
    {
        if(questCompleted == false)
        {
            OnDynamicDialogueRequested?.Invoke(npcDialogueSO , this);
            InventoryToggle.instance.UnlockandShowCursor();
            playerHasItem = false;

            
        }
    }

    public void TryCompleteQuest()
    {
        bool hasItem = true;
        for (int i = 0; i < requiredItem.Length; i++)
        {
            if (inventorySystem.HasItem(requiredItem[i]) == true)
            {

            }
            else
            {
                hasItem = false;
            }
        }

        if (hasItem == true)
        {
            questCompleted = true;
            for (int i = 0; i < requiredItem.Length; i++)
            {
                inventorySystem.RemoveItemFromInventory(requiredItem[i]);
            }
            OnQuestCompleted?.Invoke();
        }
        else
        {
            print("Player Doesn't have Item Please find then return here ");
        }
    }
}
