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
    private bool lastWalkDirection = false;
    private bool lastInteractPressed = false;
    private Interactable lookingAt;

    void Update()
    {
        // Player cannot move while talking
        if (inDialog) {
            rigidBody.velocity = new Vector2();
            if (AxisTapped("Interact") || Input.GetAxis("Cancel") > 0)  // (Input.GetAxis("Interact") > 0)
                dialogManager.SetDialogs(null);
        } else {
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

                if (AxisTapped("Interact"))  // (Input.GetAxis("Interact") > 0)
                {
                    interactNotification.GetComponent<SpriteRenderer>().enabled = false;
                    dialogManager.SetDialogs(lookingAt.dialog);
                    lookingAt = null;
                }
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

    // Will only return `true` on the first frame it's pressed, similar to `Input.GetKeyDown()`
    private bool AxisTapped (string axis)
    {
        bool returnVal = false;
        if (Input.GetAxis(axis) > 0)
        {
            if (!lastInteractPressed)
                returnVal = true;
            lastInteractPressed = true;
        } else
            lastInteractPressed = false;

        return returnVal;
    }
}
