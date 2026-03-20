using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BatteryManager batteryManager;
    public float rideDuration = 60f;
    private float timer = 0f;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;
        timer += Time.deltaTime;
        if (timer >= rideDuration)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;

        if (batteryManager.currentBattery > 50f)
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (batteryManager.currentBattery > 0f)
        {
            SceneManager.LoadScene("SmombieScene");
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}