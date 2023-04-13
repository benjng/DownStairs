using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject depthIndicator;

    void Start()
    {
        StepsSpawner.OnStepSpawn += InstantiateDepthInd;
    }

    // Spawn depthIndicator
    private void InstantiateDepthInd()
    {
        Instantiate(depthIndicator, transform);
    }
}
