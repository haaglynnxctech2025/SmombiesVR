using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Texture2D[] frames;
    public float framesPerSecond = 8f;
    private Material mat;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (frames.Length > 0)
            mat.SetTexture("_BaseMap", frames[0]);
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / framesPerSecond)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            mat.SetTexture("_BaseMap", frames[currentFrame]);
        }
    }
}
