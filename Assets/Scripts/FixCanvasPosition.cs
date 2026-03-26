using UnityEngine;

public class FixCanvasPosition : MonoBehaviour
{
    private Vector3 fixedPosition;
    private Quaternion fixedRotation;

    void Start()
    {
        fixedPosition = transform.position;
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = fixedPosition;
        transform.rotation = fixedRotation;
    }
}
