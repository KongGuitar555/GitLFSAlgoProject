using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BadApesGame/DialogueSO")]
public class NPCDialogueSO : ScriptableObject
{
    public string npcName;

    [TextArea(20 , 20)]
    public string initialDialogue;



}
