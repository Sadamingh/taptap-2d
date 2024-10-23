using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    public DialogueData dialogueData; // Assign the asset here in the Inspector

    // Reference to TMP and bubbles for Cat and NPC
    public GameObject catBubble;
    public TMP_Text catTMP;
    
    public GameObject npcBubble;
    public TMP_Text npcTMP;

    public GameObject nextLevelObject; // The object to be shown after dialogue ends

    public int currentDialogueIndex = 0;

    private void Start()
    {
        // Initially hide both bubbles and TMPs
        catBubble.SetActive(false);
        npcBubble.SetActive(false);
        catTMP.text = string.Empty;
        npcTMP.text = string.Empty;
        
        // Initially hide the "next level" object
        if (nextLevelObject != null)
        {
            nextLevelObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player presses Space or Enter to display the next dialogue
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextDialogue();
        }
    }

    public void DisplayNextDialogue()
    {
        if (currentDialogueIndex >= dialogueData.dialogueEntries.Length)
        {
            EndDialogue();
            ShowNextLevel();
            return;
        }

        var currentEntry = dialogueData.dialogueEntries[currentDialogueIndex];

        // Check who is speaking and show the relevant bubble
        if (currentEntry.speaker == "Cat")
        {
            catBubble.SetActive(true);  // Show Cat's bubble
            npcBubble.SetActive(false); // Hide NPC's bubble
            npcTMP.text = string.Empty;
            catTMP.text = currentEntry.dialogueLine;
        }
        else if (currentEntry.speaker == "NPC")
        {
            npcBubble.SetActive(true);  // Show NPC's bubble
            catBubble.SetActive(false); // Hide Cat's bubble
            catTMP.text = string.Empty;
            npcTMP.text = currentEntry.dialogueLine;
        }

        currentDialogueIndex++;
    }

    public void EndDialogue()
    {
        // Hide both bubbles and clear text when the dialogue ends
        catBubble.SetActive(false);
        npcBubble.SetActive(false);
        catTMP.text = string.Empty;
        npcTMP.text = string.Empty;
        
        Debug.Log("Dialogue Finished");
    }

    public void ShowNextLevel()
    {
        // Show the next level object (e.g., a button or indicator) when dialogue ends
        if (nextLevelObject != null)
        {
            nextLevelObject.SetActive(true);
        }
    }
}
