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
    
    public static float StepUpSpeed = 3;
    public static float VPSpawnPosY = 0.15f; // Vertical Port Spawn Position Y
    [SerializeField] private GameObject step;
    [SerializeField] private GameObject[] spawnItems;
    // Coin, Potion_R, Laser, Potion_F, Remote_Step, Potion_HP
    [SerializeField] private List<float> probabilities = new List<float> { 0.2f, 0.1f, 0.0f, 0.1f, 0.1f, 0.1f }; 
    [SerializeField] private float extraStepProb = 0.9f;
    [SerializeField] private GameObject spawnSensor;

    // Event Handler
    public delegate void PrintFloorEventHandler();
    public static event PrintFloorEventHandler PrintFloor;

    public static int CurrentFloor = 0;

    void Start()
    {
        SpawnStepsAndItems(); // Init
        SpawnSensor.SpawnStepEvent += SpawnStepsAndItems;
    }

    private void FixedUpdate()
    {
        StepUpSpeed += Time.fixedDeltaTime / Time.realtimeSinceStartup;
    }

    public Vector3 CreateStep(bool isRemoteStep) // A step set includes a step, and a possible spawn item
    {
        GameObject thisStep = Instantiate(step, gameObject.transform);
        float randWidth = Random.Range(0.0f, 1.0f);
        thisStep.transform.localPosition = Camera.main.ViewportToWorldPoint(new Vector3(randWidth, 0, 0));
        if (isRemoteStep)
            // TODO: Change the remote step sprite here
            thisStep.tag = "RemoteStep";
        thisStep.SetActive(true);
        CreateItemByChance(thisStep);
        
        // if (MenuSystem.gameMode != GameMode.Simple) {
        //     CreateItemByChance(thisStep);
        // }
        return thisStep.transform.position;
    }

    // offset extra step from base step
    public void CreateExtraStep(Vector3 baseStepPos){
        float xOffset = Random.Range(2.0f, 5.0f);
        if (Random.value < 0.5) {
            xOffset *= -1;
        }
        GameObject thisStep = Instantiate(step, gameObject.transform);
        thisStep.transform.position = baseStepPos + new Vector3(xOffset, 0, 0);
        // thisStep.transform.position += new Vector3(xOffset, 0, 0);
        thisStep.tag = "ExtraStep";
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

    // Spawn sensor tells when to spawn the next step
    void CreateSpawnSensor(Vector3 baseStepPos){
        Instantiate(spawnSensor, baseStepPos, new Quaternion(), transform);
    }

    // Spawn steps with time interval
    private void SpawnStepsAndItems()
    {
        Vector3 baseStepPos = CreateStep(false);
        CreateSpawnSensor(baseStepPos);
        if (Random.value < extraStepProb)
        {
            CreateExtraStep(baseStepPos);
        }
        CurrentFloor++;
        if (CurrentFloor%5 == 0 && CurrentFloor != 0)
            PrintFloor?.Invoke(); // broadcast PrintFloor event
    }
}

// public class StepsSpawnerStub : StepsSpawner {
//     public override void CreateStep()
//     {
//         GameObject thisStep = Instantiate(step, gameObject.transform);
//         thisStep.SetActive(true);
//     }
// }