using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class AutoStart : MonoBehaviour
{
    public float delaySeconds = 20f;
    public TextMeshProUGUI countdownText;
    private float timer = 0f;
    private bool started = false;
    private bool timerActive = false;

    void Start()
    {
        Invoke("ActivateTimer", 4f);
    }

    void ActivateTimer()
    {
        timerActive = true;
    }

    void Update()
    {
        if (started) return;
        if (!timerActive) return;

        timer += Time.deltaTime;
        float remaining = delaySeconds - timer;
        remaining = Mathf.Max(0, remaining);

        if (countdownText != null)
            countdownText.text = "SCROLL FOR YOUR LIFE IN " + Mathf.CeilToInt(remaining) + "...";

        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        if (rightHand.isValid)
        {
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed);
            if (triggerPressed)
            {
                started = true;
                SceneManager.LoadScene("MainScene");
            }
        }

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            started = true;
            SceneManager.LoadScene("MainScene");
        }

        if (timer >= delaySeconds)
        {
            started = true;
            SceneManager.LoadScene("MainScene");
        }
    }
}