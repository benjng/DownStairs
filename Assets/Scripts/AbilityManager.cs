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
                charStatus.MultiplyMoveSpeed(1.05f);
                break;
            case Abilities.MultiplyStepSpeed_110Per:
                StepsSpawner.StepUpSpeed *= 1.05f;
                break;
            case Abilities.InstantSpawn_1Step:
                stepsSpawner.CreateStep(true);
                break;
            case Abilities.HPHeal_Plus1:
                charStatus.TakeHeal(1);
                break;
            case Abilities.MultiplyGravity_110Per:
                charStatus.MultiplyGravity(1.1f);
                break;
            case Abilities.MoveSpeed_Plus1:
                charStatus.Add1MoveSpeed();
                break;
        }
    }
}
