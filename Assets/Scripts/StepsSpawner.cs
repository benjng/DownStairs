using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepsSpawner : MonoBehaviour
{
    public GameObject step;
    public GameObject[] spawnItems;
    private List<float> probabilities = new List<float> { 0.2f, 0.1f, 0.1f}; // Coin, Potion, Laser

    public float spawnInterval = 10.5f;
    public float upSpeed = 2;

    [SerializeField] private GameObject UI;

    // Event Handler
    public delegate void StepSpawnEventHandler();
    public static event StepSpawnEventHandler OnStepSpawn;

    void Start()
    {
        StartCoroutine(SpawnStepsAndItems());
    }

    private void FixedUpdate()
    {
        upSpeed += (1f * Time.fixedDeltaTime) / Time.realtimeSinceStartup ;
    }

    // Spawn steps with time interval
    private IEnumerator SpawnStepsAndItems()
    {
        void CreateSet()
        {
            GameObject thisStep = Instantiate(step, gameObject.transform);
            thisStep.SetActive(true);

            // Generate a random value between 0 and 1
            float randomValue = Random.value;
            // Calculate the cumulative probability of each item
            float cumulativeProbability = 0f;
            for (int i = 0; i < spawnItems.Length; i++)
            {
                cumulativeProbability += probabilities[i];

                // If the random value falls within the cumulative probability of an item, select it
                if (randomValue <= cumulativeProbability)
                {
                    GameObject selectedItem = spawnItems[i];
                    Debug.Log("Selected item: " + selectedItem);
                    // Generate Random Item from spawnItems list
                    thisStep.GetComponent<Step>().GenerateItem(selectedItem);
                    break;
                }
            }
        }

        while (true)
        {            
            if (Random.value < 0.3f)
            {
                CreateSet();
            }
            CreateSet();
            OnStepSpawn?.Invoke();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
