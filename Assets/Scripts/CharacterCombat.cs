using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterCombat : MonoBehaviour
{
    #region Singleton
    public static CharacterCombat instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicated CharacterCombat instance found.");
            return;
        }
        instance = this;
    }
    #endregion
    
    [SerializeField] private EquipmentData currentEquipment;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button equipmentBtn;
    [SerializeField] private Animator charAnimator;
    private int currentFaceDir = -1;

    void Start()
    {
        equipmentBtn.onClick.AddListener(AtkAnimation);
    }
    void Update()
    {
        if (joystick.Horizontal > 0){
            currentFaceDir = 1;
        } else if (joystick.Horizontal < 0){
            currentFaceDir = -1;
        }
    }

    void AtkAnimation(){
        if (currentFaceDir == 1){
            Debug.Log("Attack right");
            charAnimator.SetTrigger("fistAtkRight");
            return;
        }
        if (currentFaceDir == -1){
            Debug.Log("Attack left");
            charAnimator.SetTrigger("fistAtkLeft");
            return;
        }
    }

    public void UpdateEquipment(EquipmentData equipmentData){
        equipmentBtn.GetComponent<Image>().sprite = equipmentData.icon;
    }
}
