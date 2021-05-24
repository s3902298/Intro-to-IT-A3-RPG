using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Message messageManager;
    public Book bookManager;
    public Player player;

    DialogEvent curEvent;
    GameObject puzzle;

    public void MessageButton (int response)
    {
        SetDialogs(curEvent.GetResponseEvent(response));
    }
    
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
}
