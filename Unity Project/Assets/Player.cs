using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary wordDictionary;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public DialogManager dialogManager;
    public GameObject interactNotification;

    public float walkSpeed;

    public bool inDialog = false;
    bool lastWalkDirection = false;
    Interactable lookingAt;
    
    void Update ()
    {
        // Player cannot move while talking
        if (inDialog)
            return;

        // Extremely simple controls
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed,
                                         Input.GetAxis("Vertical") * walkSpeed);

        if (Input.GetAxis("Horizontal") != 0)
        {
            lastWalkDirection = (int)Mathf.Sign(Input.GetAxis("Horizontal")) < 0 ? true : false;
            spriteRenderer.flipX = lastWalkDirection;
        }

        // Player will focus on interactable objects and trigger their dialog events when F is pressed
        if (lookingAt != null)
        {
            interactNotification.transform.position = lookingAt.gameObject.transform.position + new Vector3(0f, 1.5f, 0f);

            if (Input.GetAxis("Interact") > 0)
            {
                interactNotification.GetComponent<SpriteRenderer>().enabled = false;
                dialogManager.SetDialog(lookingAt.dialog);
                lookingAt = null;
            }
        }
    }

    // Set the variable to the thing they're trying to interact with
    public void SetLookingAt (Interactable obj)
    {
        interactNotification.GetComponent<SpriteRenderer>().enabled = true;
        lookingAt = obj;
    }

    // Unset the variable if the focus hasn't already changed
    public void UnsetLookingAt (Interactable obj)
    {
        if (lookingAt == obj)
        {
            interactNotification.GetComponent<SpriteRenderer>().enabled = false;
            lookingAt = null;
        }
    }
}
