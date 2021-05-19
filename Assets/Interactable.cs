using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public DialogEvent dialog;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player>().SetLookingAt(this);
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player>().UnsetLookingAt(this);
    }
}
