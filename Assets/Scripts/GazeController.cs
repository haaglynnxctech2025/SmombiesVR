using UnityEngine;

public class GazeController : MonoBehaviour
{
    public float gazeDistance = 5f;
    public LayerMask zombieLayer;
    private GazeZombie currentGazedZombie = null;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, gazeDistance, zombieLayer))
        {
            GazeZombie zombie = hit.collider.GetComponent<GazeZombie>();
            if (zombie != null)
            {
                if (currentGazedZombie != zombie)
                {
                    if (currentGazedZombie != null)
                        currentGazedZombie.SetGazed(false);
                    currentGazedZombie = zombie;
                    currentGazedZombie.SetGazed(true);
                }
            }
        }
        else
        {
            if (currentGazedZombie != null)
            {
                currentGazedZombie.SetGazed(false);
                currentGazedZombie = null;
            }
        }
    }
}