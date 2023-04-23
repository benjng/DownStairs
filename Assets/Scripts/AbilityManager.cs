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

    [SerializeField] private CharacterStatus charStatus;

    void Start(){
        stepsSpawner = StepsSpawner.instance;
    }

    public void ApplyAbility(ItemData item){
        switch (item.ability){
            case Abilities.MultiplyCharRunSpeed_110Per:
                MultiplyCharMoveSpeed(1.05f);
                break;
            case Abilities.MultiplyStepSpeed_110Per:
                MultiplyStepSpeed(1.05f);
                break;
            case Abilities.InstantSpawn_1Step:
                InstantSpawn1Step();
                break;
            case Abilities.HPHeal_Plus1:
                HPHealPlus1();
                break;
            case Abilities.MultiplyGravity_110Per:
                MultiplyGravity(1.1f);
                break;
        }
    }

    public void MultiplyCharMoveSpeed(float multiplier){
        // charStatus.MoveSpeed *= multiplier;
        charStatus.MultiplyMoveSpeed(multiplier);
    }
    public void MultiplyStepSpeed(float multiplier){
        StepsSpawner.stepUpSpeed *= multiplier;
    }
    public void MultiplyGravity(float multiplier){
        charStatus.MultiplyGravity(multiplier);
    }
    public void InstantSpawn1Step(){
        stepsSpawner.CreateStep(true);
    }
    public void HPHealPlus1(){
        charStatus.TakeHeal(1);
    }
}
