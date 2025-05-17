using System.Collections.Generic;
using UnityEngine;

// @author Jake DeRoma, Discord: jaker333
[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string dialogueID;
    public List<DialogueLine> lines = new List<DialogueLine>();
}

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    public Sprite portrait;
    public AudioClip voice;
    
    [TextArea]
    public string text;

    public int nextLineIndex = -1; // -1 means end
}