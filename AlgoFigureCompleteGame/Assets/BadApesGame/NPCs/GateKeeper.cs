using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeeper : MonoBehaviour
{
    public bool questCompleted;

    public InventoryItemData[] requiredItem;

    private void Awake()
    {
        questCompleted = false;
    }


}
