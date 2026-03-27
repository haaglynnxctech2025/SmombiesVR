using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneTap : MonoBehaviour
{
    [Header("References")]
    public BatteryManager batteryManager;
    public SpriteAnimator phoneScreen;
    public AudioSource tapSound;

    [Header("Trigger Settings")]
    public float tapAmount = 10f;
    public int framesPerTap = 3;

    [Header("Thumbstick Settings")]
    public float thumbstickThreshold = 0.5f;
    public float thumbstickCooldownTime = 0.3f;
    public float thumbstickAmount = 3f;

    [Header("Gaze Settings")]
    public float gazeChargeRate = 2f;
    public float gazeDrainBoost = 8f;
    public Transform phoneTransform;

    private bool triggerWasPressed = false;
    private float thumbstickCooldown = 0f;

    void Start()
    {
        if (phoneTransform == null)
        {
            GameObject phone = GameObject.Find("Phone");
            if (phone != null)
                phoneTransform = phone.transform;
        }
    }

    void Update()
    {
        thumbstickCooldown -= Time.deltaTime;

        // PC keyboard
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Tap(tapAmount);
        }

        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        if (rightHand.isValid)
        {
            // Trigger
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed);
            if (triggerPressed && !triggerWasPressed)
            {
                Tap(tapAmount);
            }
            triggerWasPressed = triggerPressed;

            // Thumbstick — langsameres Steigen
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 thumbstick);
            bool thumbstickActive = thumbstick.magnitude > thumbstickThreshold;
            if (thumbstickActive && thumbstickCooldown <= 0f)
            {
                Tap(thumbstickAmount);
                thumbstickCooldown = thumbstickCooldownTime;
            }
        }

        // Gaze auf Handy → Battery steigt langsam
        if (IsLookingAtPhone())
        {
            batteryManager.currentBattery += gazeChargeRate * Time.deltaTime;
            batteryManager.currentBattery = Mathf.Clamp(
                batteryManager.currentBattery,
                0f,
                batteryManager.maxBattery
            );
        }
        // Gaze weggeschaut → Battery sinkt schneller
        else if (!IsLookingAtPhone())
        {
            batteryManager.currentBattery -= gazeDrainBoost * Time.deltaTime;
            batteryManager.currentBattery = Mathf.Clamp(
                batteryManager.currentBattery,
                0f,
                batteryManager.maxBattery
            );
        }
    }

    bool IsLookingAtPhone()
    {
        if (phoneTransform == null) return false;
        Vector3 directionToPhone = (phoneTransform.position - Camera.main.transform.position).normalized;
        float dot = Vector3.Dot(Camera.main.transform.forward, directionToPhone);
        return dot > 0.8f;
    }

    public void Tap(float amount)
    {
        batteryManager.AddBattery(amount);

        if (phoneScreen != null)
        {
            for (int i = 0; i < framesPerTap; i++)
            {
                phoneScreen.AdvanceFrame();
            }
        }

        if (tapSound != null)
            tapSound.Play();
    }
}