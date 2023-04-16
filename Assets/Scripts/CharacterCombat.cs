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
    [SerializeField] private GameObject projectilesHolder;
    private int currentFaceDir = -1;

    public int CurrentFaceDir { get => currentFaceDir; set => currentFaceDir = value; }

    void Start()
    {
        equipmentBtn.onClick.AddListener(UseEquipment);
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

    void UseEquipment(){
        AtkAnimation();
        if (currentEquipment.equipmentType == EquipmentData.EqType.RangedWeapon){
            // Shoot out the projectile
            GameObject thisProjectile = Instantiate(currentEquipment.projectile, projectilesHolder.transform);
            thisProjectile.GetComponent<Projectile>().ShootStraight();
        }
    }

    // Update current equipment info & sprite UI
    public void UpdateEquipment(EquipmentData equipmentData){
        currentEquipment = equipmentData;
        equipmentBtn.GetComponent<Image>().sprite = equipmentData.icon;
    }
}
