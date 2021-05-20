using System.Collections.Generic;
using UnityEngine;

// An NPC's speech, the words that are discovered, and the next event to trigger
[CreateAssetMenu(fileName = "New Dialog Event", menuName = "Events/Dialog Event")]
public class DialogEvent : ScriptableObject
{
    public string dialogText;
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