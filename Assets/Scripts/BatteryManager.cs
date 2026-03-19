using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    public Image batteryFill;
    public float maxBattery = 100f;
    public float currentBattery = 100f;
    public float drainRate = 2f;

    void Update()
    {
        currentBattery -= drainRate * Time.deltaTime;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
        batteryFill.fillAmount = currentBattery / maxBattery;
    }

    public void AddBattery(float amount)
    {
        currentBattery += amount;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
    }
}