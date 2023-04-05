using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject depthIndicator;
    [SerializeField] private GameObject depthMarker;

    private int i = 0;

    void Start()
    {
        // Subscribe to StepsSpawner OnStepSpawn event
        StepsSpawner.OnStepSpawn += InstantiateDepthInd;
    }

    // Spawn depthIndicator
    private void InstantiateDepthInd()
    {
        if (i % 3 == 0)
        {
            Instantiate(depthIndicator, transform);
        }
        else
        {
            Instantiate(depthMarker, transform);
        }
        i++;
    }
}
