using UnityEngine;

public class ScrollSkybox : MonoBehaviour
{
    public float scrollSpeed = 0.01f;

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        RenderSettings.skybox.SetFloat("_Rotation", offset * 360f);
    }
}