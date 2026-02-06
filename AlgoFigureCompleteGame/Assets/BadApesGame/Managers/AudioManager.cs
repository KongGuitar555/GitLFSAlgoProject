using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource questCompleteSound;

    private void Awake()
    {
        GateKeeper.OnQuestCompleted += PlayQuestCompleteSound;
    }

    public void PlayQuestCompleteSound()
    {
        questCompleteSound.Play();
    }
}
