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
    
    private Character character;
    private CharAnimController charAnimController;

    [SerializeField] private int maxHeatlh = 10;
    [SerializeField] private int currentHeatlh;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private EquipmentData currentEquipment;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button equipmentBtn;
    [SerializeField] private Animator charAnimator;
    [SerializeField] private GameObject projectilesHolder;
    private int currentFaceDir = -1;

    public int CurrentFaceDir { get => currentFaceDir; set => currentFaceDir = value; }

    void Start()
    {
        character = GetComponent<Character>();
        charAnimController = GetComponent<CharAnimController>();
        equipmentBtn.onClick.AddListener(UseEquipment);
        currentHeatlh = maxHeatlh;
        healthBar.SetMaxValue(maxHeatlh); // Init healthbar appearance to max hp
    }

    void Update()
    {
        if (joystick.Horizontal > 0){
            currentFaceDir = 1;
        } else if (joystick.Horizontal < 0){
            currentFaceDir = -1;
        }

        // if (Input.touchCount > 0){
        //     TakeDamage(1);
        // }
        
    }

    void AtkAnimation(){
        if (currentFaceDir == 1){
            charAnimController.ChangeState(character.charAnimStates[4]); //fist right
            return;
        }
        if (currentFaceDir == -1){
            charAnimController.ChangeState(character.charAnimStates[3]); //fist left
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

    void TakeDamage(int damage){
        currentHeatlh -= damage;
        healthBar.SetValue(currentHeatlh);
    }
}
