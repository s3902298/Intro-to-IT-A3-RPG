using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    npcSpeech,  // An NPC is talking
    book,  // Book is open
    puzzle  // Create a puzzle
}

// UI text shown, the words that are discovered, and the next event to trigger
[CreateAssetMenu(fileName = "New Dialog Event", menuName = "Events/Dialog Event")]
public class DialogEvent : ScriptableObject
{
    public EventType eventType;
    public string dialogText;
    [TextArea(minLines: 2, maxLines: 6)]
    public List<string> bookText;
    public GameObject interactableUI;
    public List<WordDefPair> scanResults;
    public List<ResponseEventPair> nextEvents;

    public DialogEvent GetResponseEvent (int response)
    {
        return nextEvents[response].nextEvent;
    }
}

// Possible responses Beepy can say and what events it triggers
[System.Serializable]  // Lets lists of this be edited in the Inspector
public class ResponseEventPair
{
    public string response;
    public DialogEvent nextEvent;
}