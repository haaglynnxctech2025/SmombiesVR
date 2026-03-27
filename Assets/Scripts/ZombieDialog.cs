using UnityEngine;
using TMPro;

public class ZombieDialog : MonoBehaviour
{
    [Header("Dialogue")]
    public string[] dialogueLines = {
        "Schau mich an...",
        "Leg das Handy weg.",
        "Wir sind gleich.",
        "Du wirst einer von uns.",
        "Scroll weiter...",
        "Bleib bei uns."
    };

    [Header("References")]
    public TextMeshPro dialogueText;
    public float displayDuration = 4f;
    public float fadeSpeed = 1f;
    public float lineInterval = 6f;

    [Header("Animation Frames")]
    public Texture2D[] normalFrames;
    public Texture2D[] aggressiveFrames;
    public float normalFPS = 6f;
    public float aggressiveFPS = 12f;

    private SpriteAnimator spriteAnimator;
    private bool isActive = false;
    private bool wasActive = false;
    private float displayTimer = 0f;
    private float timeSinceLastLine = 0f;

    void Start()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();

        if (dialogueText != null)
        {
            dialogueText.alpha = 0f;
            dialogueText.text = "";
        }
    }

    void Update()
    {
        if (!isActive)
        {
            if (dialogueText != null)
                dialogueText.alpha = Mathf.Lerp(
                    dialogueText.alpha, 0f, fadeSpeed * Time.deltaTime);
            return;
        }

        timeSinceLastLine += Time.deltaTime;
        if (timeSinceLastLine >= lineInterval)
        {
            timeSinceLastLine = 0f;
            ShowRandomLine();
        }

        displayTimer -= Time.deltaTime;
        if (displayTimer <= 0f && dialogueText != null)
        {
            dialogueText.alpha = Mathf.Lerp(
                dialogueText.alpha, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void ShowRandomLine()
    {
        if (dialogueLines.Length == 0) return;
        string line = dialogueLines[Random.Range(0, dialogueLines.Length)];

        if (dialogueText != null)
        {
            dialogueText.text = line;
            dialogueText.alpha = 1f;
            displayTimer = displayDuration;
        }
    }

    public void SetActive(bool active)
    {
        // Nur ausführen wenn sich der Status wirklich ändert!
        if (active == wasActive) return;
        wasActive = active;
        isActive = active;

        if (spriteAnimator != null)
        {
            if (active && aggressiveFrames.Length > 0)
            {
                spriteAnimator.frames = aggressiveFrames;
                spriteAnimator.framesPerSecond = aggressiveFPS;
            }
            else if (!active && normalFrames.Length > 0)
            {
                spriteAnimator.frames = normalFrames;
                spriteAnimator.framesPerSecond = normalFPS;
            }
        }

        if (active)
        {
            timeSinceLastLine = lineInterval;
        }
        else
        {
            if (dialogueText != null)
            {
                dialogueText.text = "";
                dialogueText.alpha = 0f;
                timeSinceLastLine = 0f;
            }
        }
    }
}