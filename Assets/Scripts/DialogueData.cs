using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData")]
public class DialogueData : ScriptableObject
{
    public DialogueEntry[] dialogueEntries;
}

[System.Serializable]
public class DialogueEntry
{
    public string speaker; // "Cat" or "NPC"
    public string dialogueLine;
}
