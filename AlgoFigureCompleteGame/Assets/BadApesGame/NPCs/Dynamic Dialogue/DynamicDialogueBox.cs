using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDialogueBox : MonoBehaviour
{

    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI dialogue;

    public NPCDialogueSO currentNPCDialogueSO;

    public Button tryCompleteQuestbutton;

    INPCQuestable NPCQuestInterface;

    private void Awake()
    {
        GateKeeper.OnDynamicDialogueRequested += OpenAndShowDialogue;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenAndShowDialogue(NPCDialogueSO _npcDialogueSpeaker , INPCQuestable _NPCQuestInterface)
    {
        this.gameObject.SetActive(true);
        currentNPCDialogueSO = _npcDialogueSpeaker;
        speakerName.text = _npcDialogueSpeaker.npcName;
        dialogue.text = _npcDialogueSpeaker.initialDialogue;
        AddButtonListener(_NPCQuestInterface);
    }

    public void AddButtonListener(INPCQuestable _NPCQuestInterface)
    {
        NPCQuestInterface = _NPCQuestInterface;
        tryCompleteQuestbutton.onClick.AddListener(TryCompleteQuest);
    }

    public void TryCompleteQuest()
    {
        if(NPCQuestInterface != null)
        {
            NPCQuestInterface.TryCompleteQuest();
        }
        else
        {
            Debug.LogWarning("There is no NPCQuestInterface");
        }
    }

    

    public void CloseDialogueBox()
    {
        currentNPCDialogueSO = null;
        InventoryToggle.instance.LockAndHideCursor();
        this.gameObject.SetActive(false);
    }
}
