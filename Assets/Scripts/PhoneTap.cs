using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneTap : MonoBehaviour
{
    public BatteryManager batteryManager;
    public float tapAmount = 10f;
    private bool triggerWasPressed = false;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Tap();
        }

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
    }
}