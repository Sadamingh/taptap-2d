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

    // New references for CatMove and LaserPointer scripts and Laser GameObject
    public CatMove catMove;
    public GameObject laserObject;
    private LaserPointer laserPointer;

    public bool isDiaTriggered = false; // Controls dialogue activation

    private bool canClick = true; // Prevents multiple clicks
    private float clickCooldown = 0.3f;

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
        if (isDiaTriggered && currentDialogueIndex == 0)
        {
            currentDialogueIndex++;
            return;
        }

        // Check for tap/click input to continue dialogue only if isDiaTriggered is true
        if (isDiaTriggered && canClick && Input.GetMouseButtonDown(0)) // Left mouse button or tap on mobile
        {
            Debug.Log("Hit");
            DisplayNextDialogue();
            StartCoroutine(ClickCooldown());
        }
    }

    private IEnumerator ClickCooldown()
    {
        canClick = false; // Prevent further clicks until cooldown is over
        yield return new WaitForSeconds(clickCooldown);
        canClick = true; // Allow clicks again after cooldown
    }

    public void DisplayNextDialogue()
    {
        if (currentDialogueIndex >= dialogueData.dialogueEntries.Length)
        {
            EndDialogue();
            ShowNextLevel();
            return;
        }

        Debug.Log("Current Dialogue Index: " + currentDialogueIndex);

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
