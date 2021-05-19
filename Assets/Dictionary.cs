using System.Collections.Generic;
using UnityEngine;

// Manages & stores discovered words
public class Dictionary : MonoBehaviour
{
    List<WordDefPair> discoveredWords;

}

// A word & its definition
[System.Serializable]  // Lets lists of this be edited in the Inspector
public class WordDefPair
{
    public string word;
    public string definition;
}