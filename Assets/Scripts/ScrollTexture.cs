using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.3f;
    public float scrollDirection = 1f;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed * scrollDirection;
        mat.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
    }
}