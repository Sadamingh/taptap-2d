using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;

    private Queue<string> paragraphs = new Queue<string>();
    private bool conversationEnded;

    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        // If there is nothing in the queue
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //start a conversation
                StartConversation(dialogueText);
            }
            else
            {
                //end a conversation
                EndConversation();
            }
        }
        // If there is smth in the queue

    }

    private void StartConversation(DialogueText dialogueText)
    {
        // activate gameObject (the dialogue box image)
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        // update NPC's name (the speaker)
        NPCNameText.text = dialogueText.npcName;

        // add dialogue text into the queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
            

    }

    private void EndConversation()
    {

    }

}
