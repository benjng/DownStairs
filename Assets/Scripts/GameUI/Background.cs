using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject depthIndicator;
    [SerializeField] private GameObject depthMarker;

    void Start()
    {
        // Subscribe to StepsSpawner OnStepSpawn event
        StepsSpawner.OnStepSpawn += InstantiateDepthInd;
    }

    // Spawn depthIndicator
    private void InstantiateDepthInd()
    {
        Instantiate(depthIndicator, transform);
    }
}
