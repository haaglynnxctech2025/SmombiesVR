using UnityEngine;

public class GazeZombie : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 0.5f;
    public float retreatSpeed = 0.8f;
    public float stopDistance = 1.2f;

    [Header("Battery")]
    public BatteryManager batteryManager;
    public float extraDrainRate = 5f;

    [Header("Phone Gaze")]
    public Transform phoneTransform;
    public float phoneGazeDistance = 0.5f;

    private Vector3 startPosition;
    private bool isGazedAt = false;

    void Start()
    {
        startPosition = transform.position;

        if (phoneTransform == null)
        {
            GameObject phone = GameObject.Find("Phone");
            if (phone != null)
                phoneTransform = phone.transform;
        }
    }

    void Update()
    {
        bool playerLookingAtPhone = IsPlayerLookingAtPhone();

        if (isGazedAt && !playerLookingAtPhone)
        {
            float distanceToPlayer = Vector3.Distance(
                transform.position,
                Camera.main.transform.position
            );

            if (distanceToPlayer > stopDistance)
            {
                Vector3 directionToPlayer = (Camera.main.transform.position - transform.position).normalized;
                directionToPlayer.y = 0;
                transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
            }

            if (batteryManager != null)
            {
                batteryManager.currentBattery -= extraDrainRate * Time.deltaTime;
                batteryManager.currentBattery = Mathf.Clamp(
                    batteryManager.currentBattery,
                    0f,
                    batteryManager.maxBattery
                );
            }
        }
        else
        {
            float distanceToStart = Vector3.Distance(transform.position, startPosition);
            if (distanceToStart > 0.05f)
            {
                Vector3 directionToStart = (startPosition - transform.position).normalized;
                transform.position += directionToStart * retreatSpeed * Time.deltaTime;
            }
        }
    }

    bool IsPlayerLookingAtPhone()
    {
        if (phoneTransform == null) return false;

        Vector3 directionToPhone = (phoneTransform.position - Camera.main.transform.position).normalized;
        float dot = Vector3.Dot(Camera.main.transform.forward, directionToPhone);
        return dot > 0.8f;
    }

    public void SetGazed(bool gazed)
    {
        isGazedAt = gazed;
    }
}
