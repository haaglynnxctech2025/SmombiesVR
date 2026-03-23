using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneTap : MonoBehaviour
{
    [Header("References")]
    public BatteryManager batteryManager;
    public SpriteAnimator phoneScreen;

    [Header("Settings")]
    public float tapAmount = 10f;
    public int framesPerTap = 3;

    private bool triggerWasPressed = false;

    void Update()
    {
        // PC keyboard for testing
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Tap();
        }

        // Quest 3 right trigger
        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        if (rightHand.isValid)
        {
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed);
            if (triggerPressed && !triggerWasPressed)
            {
                Tap();
            }
            triggerWasPressed = triggerPressed;
        }
    }

    public void Tap()
    {
        batteryManager.AddBattery(tapAmount);

        if (phoneScreen != null)
        {
            for (int i = 0; i < framesPerTap; i++)
            {
                phoneScreen.AdvanceFrame();
            }
        }
    }
}