using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spike;

    private int duplicateQty = 20;
    private float duplicateDist = 1.3f;
    private float xOffset = 0.3f;
    private float yOffset = -1.0f;

    void Start()
    {
        for (int i = 0; i < duplicateQty; i++)
        {
            GameObject currentSpike = Instantiate(spike, gameObject.transform);
            currentSpike.SetActive(true);
            currentSpike.transform.localPosition = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
            currentSpike.transform.position += new Vector3(duplicateDist * i + xOffset, yOffset, 0);
        }
    }
}
