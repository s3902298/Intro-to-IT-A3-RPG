using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public List<GameObject> dialogButtons;
    public Player player;

    DialogEvent curEvent;

    public void TriggerEvent (int response)
    {
        SetDialog(curEvent.GetResponseEvent(response));
    }

    // Hides or shows dialog elements as necessary for an event
    public void SetDialog (DialogEvent dialog)
    {
        curEvent = dialog;
        player.inDialog = dialog;

        // Set main dialog text vars
        GetComponent<Image>().enabled = dialog;
        Text mainText = GetComponentInChildren<Text>();
        mainText.enabled = dialog;
        mainText.text = dialog ? dialog.dialogText : "";

        // Loop through all the dialog buttons
        for (int b = 0; b < dialogButtons.Count; b++)
        {
            bool status;
            string dialogText;

            // Check if the dialog exists, and then if the button has a corresponding response
            if (dialog && dialog.nextEvents.Count > b)
            {
                status = true;
                dialogText = dialog.nextEvents[b].response;
            }
            else
            {
                status = false;
                dialogText = "";
            }

            // Set button vars
            dialogButtons[b].GetComponent<Button>().interactable = status;
            Text btnText = dialogButtons[b].GetComponentInChildren<Text>();
            btnText.enabled = status;
            btnText.text = dialogText;
        }
    }
}
