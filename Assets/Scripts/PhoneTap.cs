using UnityEngine;

public class PhoneTap : MonoBehaviour
{
    public BatteryManager batteryManager;
    public float tapAmount = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tap();
        }
    }

    public void Tap()
    {
        batteryManager.AddBattery(tapAmount);
    }
}