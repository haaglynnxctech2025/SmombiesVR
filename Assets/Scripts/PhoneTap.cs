using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneTap : MonoBehaviour
{
    public BatteryManager batteryManager;
    public float tapAmount = 10f;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Tap();
        }
    }

    public void Tap()
    {
        batteryManager.AddBattery(tapAmount);
    }
}