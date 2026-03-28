using UnityEngine;
using UnityEngine.UI;

public class PhoneFlicker : MonoBehaviour
{
    [Header("References")]
    public BatteryManager batteryManager;
    public GameObject phoneScreenObject;
    public Image batteryFill;

    [Header("Settings")]
    public float flickerThreshold = 20f;
    public float flickerSpeed = 0.08f;

    [Header("Colors")]
    public Color flickerColor = new Color(1f, 0f, 0f, 1f);
    public Color normalColor = new Color(0f, 1f, 0f, 1f);

    private float flickerTimer = 0f;
    private bool isRed = false;
    private Renderer phoneRenderer;
    private Material phoneMat;

    void Start()
    {
        if (phoneScreenObject != null)
            phoneRenderer = phoneScreenObject.GetComponent<Renderer>();

        if (phoneRenderer != null)
            phoneMat = phoneRenderer.material;
    }

    void Update()
    {
        if (batteryManager == null) return;

        if (batteryManager.currentBattery <= flickerThreshold)
        {
            flickerTimer += Time.deltaTime;
            if (flickerTimer >= flickerSpeed)
            {
                flickerTimer = 0f;
                isRed = !isRed;

                // Phone Screen blinkt rot
                if (phoneMat != null)
                {
                    phoneMat.color = isRed
                        ? new Color(1f, 0f, 0f, 1f)
                        : Color.white;

                    // Emission für leuchtendes Rot
                    phoneMat.SetColor("_EmissionColor",
                        isRed
                        ? new Color(3f, 0f, 0f, 1f)
                        : Color.black);
                }

                // Battery Bar blinkt auch rot
                if (batteryFill != null)
                    batteryFill.color = isRed
                        ? new Color(1f, 0f, 0f, 1f)
                        : normalColor;
            }
        }
        else
        {
            isRed = false;
            if (phoneMat != null)
            {
                phoneMat.color = Color.white;
                phoneMat.SetColor("_EmissionColor", Color.black);
            }
            if (batteryFill != null)
                batteryFill.color = normalColor;
        }
    }
}