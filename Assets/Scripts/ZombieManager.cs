using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public ZombieDialog[] zombies;
    public float aggressiveDistance = 1.5f;
    private ZombieDialog currentClosest = null;

    void Update()
    {
        ZombieDialog closest = GetClosestZombie();
        float closestDistance = GetDistanceToZombie(closest);

        if (closest != currentClosest)
        {
            if (currentClosest != null)
                currentClosest.SetActive(false);
            currentClosest = closest;
        }

        if (currentClosest != null)
        {
            if (closestDistance <= aggressiveDistance)
                currentClosest.SetActive(true);
            else
                currentClosest.SetActive(false);
        }
    }

    float GetDistanceToZombie(ZombieDialog zombie)
    {
        if (zombie == null) return float.MaxValue;
        return Vector3.Distance(
            Camera.main.transform.position,
            zombie.transform.position
        );
    }

    ZombieDialog GetClosestZombie()
    {
        ZombieDialog closest = null;
        float closestDistance = float.MaxValue;

        foreach (ZombieDialog zombie in zombies)
        {
            if (zombie == null) continue;
            float distance = Vector3.Distance(
                Camera.main.transform.position,
                zombie.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = zombie;
            }
        }

        return closest;
    }
}