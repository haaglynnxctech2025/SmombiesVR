using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}