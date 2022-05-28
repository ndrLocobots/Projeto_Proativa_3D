using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    private  dialog robotDialogue;

    void Awake()
    {
        robotDialogue = FindObjectOfType<dialog>();
    }

    public void NextSentence()
    {
        robotDialogue.NextSentence();
    }
    public void BackSentence()
    {
        robotDialogue.BackSentence();
    }
    public void Skip()
    {
        robotDialogue.Skip();
    }
}
