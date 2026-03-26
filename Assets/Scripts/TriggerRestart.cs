using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TriggerRestart : MonoBehaviour
{
    public string sceneToLoad = "StartScene";
    private bool triggerWasPressed = false;
    private float delayBeforeActive = 2f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < delayBeforeActive) return;

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        if (rightHand.isValid)
        {
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed);
            if (triggerPressed && !triggerWasPressed)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            triggerWasPressed = triggerPressed;
        }
    }
}