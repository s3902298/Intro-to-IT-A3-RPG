using System.Collections.Generic;
using UnityEngine;

// An NPC's speech, the words that are discovered, and the next event to trigger
[CreateAssetMenu(fileName = "New Dialog Event", menuName = "Events/Dialog Event")]
public class DialogEvent : ScriptableObject
{
    public string dialogText;
    public List<WordDefPair> scanResults;
    public List<ResponseEventPair> nextEvents;

    // Will show a message box and chat options
    public void Trigger ()
    {
        Debug.Log(dialogText);
    }

    // Dialog options will call 
    public void Respond (int response)
    {
        DialogEvent next = nextEvents[response].nextEvent;
        if (next != null)
            next.Trigger();
    }
}

// Possible responses Beepy can say and what events it triggers
[System.Serializable]  // Lets lists of this be edited in the Inspector
public class ResponseEventPair
{
    public string response;
    public DialogEvent nextEvent;
}