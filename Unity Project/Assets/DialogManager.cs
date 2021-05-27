using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Message messageManager;
    public Book bookManager;
    public Player player;
    public Dictionary dictionary;

    DialogEvent curEvent;
    GameObject puzzle;

    public void MessageButton (int response)
    {
        SetDialogs(curEvent.GetResponseEvent(response));
    }
    
    // Enables or disables each dialog based on the type of event
    public void SetDialogs (DialogEvent dialog)
    {
        curEvent = dialog;
        player.inDialog = dialog;

        bookManager.SetBook(dialog && dialog.eventType == EventType.book ? dialog : null);
        messageManager.SetDialog(dialog && dialog.eventType == EventType.npcSpeech ? dialog : null);

        if (dialog && dialog.eventType == EventType.puzzle)
            puzzle = Instantiate(dialog.interactableUI);
        else
            Destroy(puzzle);
    }

    // Adds all of the current event's definitions to the dictionary
    public void ScanDefinitions ()
    {
        if (curEvent)
        {
            foreach (WordDefPair definition in curEvent.scanResults)
                dictionary.AddToDictionary(definition);
        }
    }
}
