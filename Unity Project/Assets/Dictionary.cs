using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages & stores discovered words
public class Dictionary : MonoBehaviour
{
    public Text dictionaryText;
    public Scrollbar toggledScrollbar;
    public List<Image> toggledImages;

    private List<WordDefPair> discoveredWords;
    
    void Start ()
    {
        discoveredWords = new List<WordDefPair>();
    }

    // Toggles the dictionary pop-up
    public void ToggleDictionary ()
    {
        dictionaryText.enabled = !dictionaryText.enabled;
        toggledScrollbar.interactable = dictionaryText.enabled;
        foreach (Image img in toggledImages)
            img.enabled = dictionaryText.enabled;
    }

    // Puts a definition into the list
    public void AddToDictionary (WordDefPair definition)
    {
        if (discoveredWords.Contains(definition))
            return;

        discoveredWords.Add(definition);
        dictionaryText.text += definition.word + ": " + definition.definition + "\n\n";
    }
}

// A word & its definition
[System.Serializable]  // Lets lists of this be edited in the Inspector
public class WordDefPair
{
    public string word;
    public string definition;
}