using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        GateKeeper.OnQuestCompleted += Opengate;
    }

    public void Opengate()
    {
        print("Open Gate");
        animator.SetTrigger("OpenGate");
    }
}
