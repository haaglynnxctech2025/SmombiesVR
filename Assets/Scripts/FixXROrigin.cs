using UnityEngine;

public class FixXROrigin : MonoBehaviour
{
    private float fixedY;

    void Start()
    {
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;
    }
}