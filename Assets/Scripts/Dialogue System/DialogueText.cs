using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]

public class DialogueText : ScriptableObject
{
    public string npcName;

    [TextArea(5, 10)] //dialouge box size in Unity Editor
    public string[] paragraphs; //hold conversation text
}
