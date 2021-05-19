using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary wordDictionary;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;

    public float walkSpeed;

    bool lastWalkDirection = false;

    void Start ()
    {
        
    }
    
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
    }
}
