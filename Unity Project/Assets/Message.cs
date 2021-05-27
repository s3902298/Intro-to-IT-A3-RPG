using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public List<GameObject> dialogButtons;
    public Button scanButton;

    // Hides or shows dialog elements as necessary for an event
    public void SetDialog (DialogEvent dialog)
    {
        // Set main dialog text vars
        GetComponent<Image>().enabled = dialog;
        Text mainText = GetComponentInChildren<Text>();
        mainText.enabled = dialog;
        mainText.text = dialog ? dialog.dialogText : "";

        // Loop through all the dialog buttons
        for (int b = 0; b < dialogButtons.Count; b++)
        {
            bool status = false;
            string dialogText = "";

            // Check if the dialog exists, and then if the button has a corresponding response
            if (dialog && dialog.nextEvents.Count > b)
            {
                status = true;
                dialogText = dialog.nextEvents[b].response;
            }

            // Set button vars
            dialogButtons[b].GetComponent<Button>().interactable = status;
            Text btnText = dialogButtons[b].GetComponentInChildren<Text>();
            btnText.enabled = status;
            btnText.text = dialogText;
        }

        // Set scan vars, only if there is something to scan
        scanButton.interactable = dialog && dialog.scanResults.Count > 0;
        scanButton.GetComponentInChildren<Text>().enabled = dialog && dialog.scanResults.Count > 0;
    }
}
