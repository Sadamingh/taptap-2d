using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Cat : NPC, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;
    public override void Interact()
    {
        // Put actions for NPC (Test_Cat, in this case) below
        Talk(dialogueText);
        Debug.Log("Start talking");
    }

    public void Talk(DialogueText dialogueText)
    {
        //Start conversation
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
