using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] private float characterGravity = 1.1f;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private Joystick joystick;
    [SerializeField] private RuntimeAnimatorController[] animatorControllers;
    [SerializeField] private CharAnimController charAnimController;
    public CharAnimState[] charAnimStates;


    private bool isFalling = true;
    [SerializeField] private float moveSpeed = 10;
    private string currentState = "firstFall";
    public Animator animator;
    
    public float XInput { get; set; }
    public float ScreenLx { get; set; }
    public float ScreenRx { get; set; }
    public Rigidbody2D Rb { get; set; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public string CurrentState { get => currentState; set => currentState = value; }
    public bool IsFalling { get => isFalling; set => isFalling = value; }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        SelectAnimatorController();
        SetScreenLR();
    }

    void SetScreenLR(){
        ScreenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        ScreenLx = -ScreenRx;
    }

    void SelectAnimatorController(){
        if (MenuSystem.charSkin == CharSkin.Boy){
            animator.runtimeAnimatorController = animatorControllers[0];
        } else if (MenuSystem.charSkin == CharSkin.Girl) {
            animator.runtimeAnimatorController = animatorControllers[1];
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (Rb.velocity.y > -0.01) {
            charAnimController.ChangeState(charAnimStates[0]); //IDLE
        }
    }

    public virtual void AnimationStateController()
    {   
        if (Rb.velocity.y < -0.5) { 
            charAnimController.ChangeState(charAnimStates[5]); // StartFalling
            return; // If char falling physically, no change allowed
        }
        if (XInput < 0) {
            charAnimController.ChangeState(charAnimStates[1]); //LEFT
        } else if (XInput > 0) {
            charAnimController.ChangeState(charAnimStates[2]); //RIGHT
        } else {
            charAnimController.ChangeState(charAnimStates[0]); //IDLE
        }
    }

    public void Movement()
    {
        XInput = joystick.Horizontal;
        float currentMovement = XInput * moveSpeed * Time.fixedDeltaTime;
        transform.position += new Vector3(currentMovement, 0, 0);
        
        // Character Warpping
        if (transform.position.x < ScreenLx)
        {
            transform.position = new Vector3(ScreenRx, transform.position.y, transform.position.z);
        } else if (transform.position.x > ScreenRx)
        {
            transform.position = new Vector3(ScreenLx, transform.position.y, transform.position.z);
        }
    }

    public void InitCharGravity(float gravity){
        // Character Gravity Init
        if (Rb.gravityScale == 0)
        {
            Rb.gravityScale = gravity;
        }
    }

    public void CheckCharSurvive(){
        // When character touching bottom
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            // SceneManager.LoadScene(3);
        }
    }
    
    void FixedUpdate()
    {
        // Check if game has started by UI counter
        if (!GameStarter.gameStarted) return;

        InitCharGravity(characterGravity);
        AnimationStateController();
        Movement();
        CheckCharSurvive();
    }


    // public class CharacterStub : Character 
    // {
    //     public override void AnimationStateController()
    //     {
    //         if (currentState == "firstFall"){
    //             return;
    //         }
    //         if (Rb.velocity.y < -0.5)
    //         {
    //             if (isFalling) // Return if already isFalling
    //                 return;
    //             isFalling = true;
    //             return;
    //         }

    //         // Not falling
    //         isFalling = false;
    //         string newState;

    //         if (XInput < 0) {
    //             newState = "isWalkingLeft";
    //         } else if (XInput > 0) {
    //             newState = "isWalkingRight";
    //         } else {
    //             newState = "isIdle";
    //         }

    //         // Return if new is current
    //         if (newState == currentState) {
    //             return;
    //         }
    //         currentState = newState;
    //     }
    // }
}