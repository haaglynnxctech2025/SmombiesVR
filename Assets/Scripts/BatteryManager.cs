using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour
{
    public Image batteryFill;
    public float maxBattery = 100f;
    public float currentBattery = 100f;
    public float drainRate = 10f;

    private Color colorGreen = new Color(0f, 1f, 0f);
    private Color colorYellow = new Color(1f, 0.8f, 0f);
    private Color colorRed = new Color(1f, 0f, 0f);

    void Update()
    {
        currentBattery -= drainRate * Time.deltaTime;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
        batteryFill.fillAmount = currentBattery / maxBattery;
        UpdateBatteryColor();
    }

    void UpdateBatteryColor()
    {
        float percent = currentBattery / maxBattery;
        if (percent > 0.5f)
        {
            float t = (percent - 0.5f) * 2f;
            batteryFill.color = Color.Lerp(colorYellow, colorGreen, t);
        }
        else
        {
            float t = percent * 2f;
            batteryFill.color = Color.Lerp(colorRed, colorYellow, t);
        }
    }

    public void AddBattery(float amount)
    {
        currentBattery += amount;
        currentBattery = Mathf.Clamp(currentBattery, 0f, maxBattery);
    }

    public bool IsDead()
    {
        return currentBattery <= 0f;
    }
}