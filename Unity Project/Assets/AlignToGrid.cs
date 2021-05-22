using UnityEngine;

// Aligns sprites to the pixel grid when moving them around in the editor
[ExecuteInEditMode]
public class AlignToGrid : MonoBehaviour
{
    Vector3 offset;
    SpriteRenderer sprite;

    void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        offset = new Vector2((sprite.sprite.texture.width % 2) * 0.04f,
                             (sprite.sprite.texture.height % 2) * 0.04f);
    }

    void Update ()
    {
        Vector3 pos = transform.position;
        pos.x = RoundToMultiple(pos.x, 0.08f, offset.x);
        pos.y = RoundToMultiple(pos.y, 0.08f, offset.y);
        transform.position = pos;
    }

    float RoundToMultiple (float val, float mult, float off)
    {
        return Mathf.Round(val / mult - off) * mult + off;
    }
}
