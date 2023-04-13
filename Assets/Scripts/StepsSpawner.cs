using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepsSpawner : MonoBehaviour
{
    #region Singleton
    public static StepsSpawner instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of StepsSpawner found!");
            return;
        }
        instance = this; // Create the unique instance of StepsSpawner
    }
    #endregion
    
    public GameObject step;
    public GameObject[] spawnItems;
    // Coin, Potion_R, Laser, Potion_F, Remote_Step
    public List<float> probabilities = new List<float> { 0.2f, 0.1f, 0.1f, 0.1f, 0.1f }; 

    public float spawnInterval = 1;
    public static float stepUpSpeed = 2;

    // Event Handler
    public delegate void StepSpawnEventHandler();
    public static event StepSpawnEventHandler OnStepSpawn;

    void Start()
    {
        StartCoroutine(SpawnStepsAndItems());
    }

    private void FixedUpdate()
    {
        stepUpSpeed += (1f * Time.fixedDeltaTime) / Time.realtimeSinceStartup;
    }

    public virtual void CreateStep() // A set includes a step, and a possible spawn item
    {
        GameObject thisStep = Instantiate(step, gameObject.transform);
        thisStep.SetActive(true);

        // No item generate for simple mode
        if (GameManager.gameMode != GameManager.GameMode.Simple) {
            Debug.Log("Not simple mode, creating extra item");
            CreateItemByChance(thisStep);
        }
    }

    public void CreateItemByChance(GameObject thisStep){
        
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
                // Generate the selected Random Item from spawnItems list
                thisStep.GetComponent<Step>().GenerateItem(selectedItem);
                break;
            }
        }
    }

    // Spawn steps with time interval
    private IEnumerator SpawnStepsAndItems()
    {
        while (true)
        {
            if (Random.value < 0.3f)
            {
                CreateStep();
            }
            CreateStep();
            OnStepSpawn?.Invoke(); // broadcast OnStepSpawn event
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

public class StepsSpawnerStub : StepsSpawner {
    public override void CreateStep()
    {
        GameObject thisStep = Instantiate(step, gameObject.transform);
        thisStep.SetActive(true);
    }
}