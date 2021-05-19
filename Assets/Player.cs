using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary wordDictionary;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public GameObject interactNotification;

    public float walkSpeed;

    bool lastWalkDirection = false;
    Interactable lookingAt;
    
    void Update ()
    {
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
            interactNotification.transform.position = lookingAt.gameObject.transform.localPosition + new Vector3(0f, 1.5f, 0f);

            if (Input.GetAxis("Interact") > 0)
            {
                interactNotification.GetComponent<SpriteRenderer>().enabled = false;
                lookingAt.dialog.Trigger();
                lookingAt = null;
            }
        }
    }

    // Set the variable to the thing they're trying to interact with
    public void SetLookingAt (Interactable obj)
    {
        interactNotification.GetComponent<SpriteRenderer>().enabled = true;
        lookingAt = obj;
        Debug.Log("Focused on " + obj);
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
