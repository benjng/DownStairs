using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    #region Singleton
    public static AbilityManager instance;
    private StepsSpawner stepsSpawner;

    void Awake(){
        if (instance != null){
            Debug.LogWarning("More than one AbilityManager instance created!");
        }
        instance = this;
    }

    #endregion

    public Character character;
    void Start(){
        stepsSpawner = StepsSpawner.instance;
    }

    public void MultiplyCharRunSpeed(float multiplier){
        character.MoveSpeed *= multiplier;
    }
    public void MultiplyStepSpeed(float multiplier){
        StepsSpawner.stepUpSpeed *= multiplier;
    }
    public void InstantSpawn1Step(){
        stepsSpawner.CreateStep();
    }
}
