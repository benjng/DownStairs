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
    
    public static float stepUpSpeed = 2;
    [SerializeField] private GameObject step;
    [SerializeField] private GameObject[] spawnItems;
    // Coin, Potion_R, Laser, Potion_F, Remote_Step, Poop
    [SerializeField] private List<float> probabilities = new List<float> { 0.2f, 0.1f, 0.0f, 0.1f, 0.1f, 0.1f }; 

    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private float extraStepProb = 0.9f;

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

    public Vector3 CreateStep() // A set includes a step, and a possible spawn item
    {
        GameObject thisStep = Instantiate(step, gameObject.transform);
        float randWidth = Random.Range(0.0f, 1.0f);
        thisStep.transform.localPosition = Camera.main.ViewportToWorldPoint(new Vector3(randWidth, 0, 0));
        thisStep.SetActive(true);

        // No item generate for simple mode
        if (MenuSystem.gameMode != GameMode.Simple) {
            CreateItemByChance(thisStep);
        }
        return thisStep.transform.position;
    }

    // offset extra step from base step
    public void CreateExtraStep(Vector3 baseStepPos){
        float xOffset = Random.Range(2, 5);
        if (Random.value < 0.5) {
            xOffset *= -1;
        }
        GameObject thisStep = Instantiate(step, gameObject.transform);
        thisStep.transform.position = baseStepPos;
        thisStep.transform.position += new Vector3(xOffset, 0, 0);
        thisStep.SetActive(true);
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
            Vector3 baseStepPos = CreateStep();
            if (Random.value < extraStepProb)
            {
                CreateExtraStep(baseStepPos);
            }
            OnStepSpawn?.Invoke(); // broadcast OnStepSpawn event
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

// public class StepsSpawnerStub : StepsSpawner {
//     public override void CreateStep()
//     {
//         GameObject thisStep = Instantiate(step, gameObject.transform);
//         thisStep.SetActive(true);
//     }
// }