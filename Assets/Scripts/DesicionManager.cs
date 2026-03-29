using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class DecisionManager : MonoBehaviour
{
    private bool decided = false;
    private float delayBeforeActive = 2f;
    private float timer = 0f;
    private bool triggerWasPressed = false;
    private bool thumbstickWasActive = false;
    public float thumbstickThreshold = 0.5f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < delayBeforeActive) return;
        if (decided) return;

        UnityEngine.XR.InputDevice rightHand = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        if (rightHand.isValid)
        {
           
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool triggerPressed);
            if (triggerPressed && !triggerWasPressed)
            {
                decided = true;
                SceneManager.LoadScene("WinScene");
            }
            triggerWasPressed = triggerPressed;

         
            rightHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 thumbstick);
            bool thumbstickActive = thumbstick.magnitude > thumbstickThreshold;
            if (thumbstickActive && !thumbstickWasActive)
            {
                decided = true;
                SceneManager.LoadScene("LoseScene");
            }
            thumbstickWasActive = thumbstickActive;
        }

     
        if (Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                decided = true;
                SceneManager.LoadScene("WinScene");
            }
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                decided = true;
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
}