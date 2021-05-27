using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public List<GameObject> pages;
    public Button scanButton;

    private int pageNum;
    private List<string> pageTexts;

    // Hides or shows the book as necessary for an event
    public void SetBook (DialogEvent dialog)
    {
        // Set book background vars
        GetComponent<Image>().enabled = dialog;

        pageTexts = dialog ? dialog.bookText : null;
        pageNum = 0;
        UpdatePages();
        
        // Set scan vars, only if there is something to scan
        scanButton.interactable = dialog && dialog.scanResults.Count > 0;
        scanButton.GetComponentInChildren<Text>().enabled = dialog && dialog.scanResults.Count > 0;
    }

    // Changes the page by some amount
    public void ChangePage (int pnum)
    {
        pageNum += pages.Count * pnum;

        if (pageNum < 0)
            pageNum = 0;
        if (pageNum >= pageTexts.Count)
            pageNum = (pageTexts.Count - pages.Count);

        UpdatePages();
    }

    // Updates the page texts - would be in `SetBook()` but needs to happen after changing pages too
    private void UpdatePages ()
    {
        // Loop through both pages
        for (int p = 0; p < pages.Count; p++)
        {
            bool status = false;
            string pageText = "";

            if (pageTexts != null && pageTexts.Count > pageNum + p)
            {
                status = true;
                pageText = pageTexts[pageNum + p];
            }

            // Set button/page vars
            pages[p].GetComponent<Button>().interactable = status;
            pages[p].GetComponent<Text>().text = pageText;
        }
    }
}
