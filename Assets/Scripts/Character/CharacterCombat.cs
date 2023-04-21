using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // [SerializeField] private int maxHeatlh = 10;
    // [SerializeField] private int currentHeatlh;
    // [SerializeField] private HealthBar healthBar;
    [SerializeField] private EquipmentData currentEquipment;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button equipmentBtn;
    [SerializeField] private Animator charAnimator;
    [SerializeField] private GameObject projectilesHolder;

    
    // [SerializeField] private float currentGravity = 1.1f;
    // [SerializeField] private float maxGravity = 3f;
    // [SerializeField] private GravityBar gravityBar;
    
    // private Rigidbody2D rb;
    private int currentFaceDir = -1;
    public int CurrentFaceDir { get => currentFaceDir; set => currentFaceDir = value; }

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        // rb.gravityScale = 0;
        character = GetComponent<Character>();
        charAnimController = GetComponent<CharAnimController>();
        equipmentBtn.onClick.AddListener(UseEquipment);
        // InitHP();
        // InitGravity();
    }

    // void FixedUpdate(){
    //     if (!GameStarter.gameStarted) return;
    //     UpdateGravity(currentGravity);
    // }

    void Update()
    {
        if (!GameStarter.gameStarted) return;
        if (joystick.Horizontal > 0){
            currentFaceDir = 1;
        } else if (joystick.Horizontal < 0){
            currentFaceDir = -1;
        }
    }

    // void InitGravity(){
    //     gravityBar.SetMaxValue(maxGravity); // Init max gravity appearance
    //     gravityBar.SetValue(currentGravity); // 
    // }

    // void UpdateGravity(float gravity){
    //     rb.gravityScale = gravity;
    // }

    // void InitHP(){
    //     currentHeatlh = maxHeatlh;
    //     healthBar.SetMaxValue(maxHeatlh); // Init healthbar appearance to max hp
    // }

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

    // public void TakeDamage(int damage){
    //     currentHeatlh -= damage;
    //     healthBar.SetValue(currentHeatlh);
    //     if (currentHeatlh <= 0)
    //         SceneManager.LoadScene(3);
    // }
    // public void TakeHeal(int heal){
    //     if (currentHeatlh == maxHeatlh) return;
    //     currentHeatlh += heal;
    //     healthBar.SetValue(currentHeatlh);
    // }
    // public void MultiplyGravity(float multiplier){
    //     currentGravity *= multiplier;
    //     gravityBar.SetValue(currentGravity);
    // }
}
