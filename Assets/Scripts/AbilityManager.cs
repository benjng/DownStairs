using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    #region Singleton
    public static AbilityManager instance;
    void Awake(){
        if (instance != null){
            Debug.LogWarning("Duplicated AbilityManager instance found.");
        }
        instance = this;
    }
    #endregion

    [SerializeField] private CharacterStatus charStatus;
    [SerializeField] private StepsSpawner stepsSpawner;

    [SerializeField] private int healAmount = 1;
    [SerializeField] private float moveSpeedAmount = 1.0f;

    public void ApplyAbility(ItemData item){
        switch (item.ability){
            case Abilities.TimePause:
                // TODO: Implement time pause logic
                // StepsSpawner.StepUpSpeed *= 1.05f;
                break;
            case Abilities.InstantSpawnStep:
                stepsSpawner.CreateStep(true);
                break;
            case Abilities.HPHeal:
                charStatus.TakeHeal(healAmount);
                break;
            case Abilities.IncreaseGravity:
                charStatus.MultiplyGravity(1.1f);
                break;
            case Abilities.IncreaseMoveSpeed:
                charStatus.AddMoveSpeed(moveSpeedAmount);
                break;
        }
    }
}
