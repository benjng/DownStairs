using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    #region Singleton
    public static AbilityManager instance;
    private StepsSpawner stepsSpawner;
    void Awake(){
        if (instance != null){
            Debug.LogWarning("Duplicated AbilityManager instance found.");
        }
        instance = this;
    }
    #endregion

    [SerializeField] private Character character;
    [SerializeField] private CharacterStatus charStatus;

    void Start(){
        stepsSpawner = StepsSpawner.instance;
    }

    public void MultiplyCharRunSpeed(float multiplier){
        character.MoveSpeed *= multiplier;
    }
    public void MultiplyStepSpeed(float multiplier){
        StepsSpawner.stepUpSpeed *= multiplier;
    }
    public void MultiplyGravity(float multiplier){
        charStatus.MultiplyGravity(multiplier);
    }
    public void InstantSpawn1Step(){
        stepsSpawner.CreateStep();
    }
    public void HPHealPlus1(){
        charStatus.TakeHeal(1);
    }
}
