using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [Header("Frames")]
    public Texture2D[] frames;
    public float framesPerSecond = 8f;

    [Header("Settings")]
    public bool autoAnimate = true;

    private Material mat;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (frames.Length > 0)
        {
            mat.SetTexture("_BaseMap", frames[0]);
            mat.SetTexture("_MainTex", frames[0]);
        }
    }

    void Update()
    {
        if (!autoAnimate) return;
        if (frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / framesPerSecond)
        {
            timer = 0f;
            AdvanceFrame();
        }
    }

    public void AdvanceFrame()
    {
        if (frames.Length == 0) return;
        currentFrame = (currentFrame + 1) % frames.Length;
        mat.SetTexture("_BaseMap", frames[currentFrame]);
        mat.SetTexture("_MainTex", frames[currentFrame]);
    }
}