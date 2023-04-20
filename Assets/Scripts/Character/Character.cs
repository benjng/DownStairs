using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public CharAnimState[] charAnimStates;

    [SerializeField] private Animator animator;
    [SerializeField] private float characterGravity = 1.1f;
    // [SerializeField] private GameObject gameManager;
    [SerializeField] private Joystick joystick;
    [SerializeField] private RuntimeAnimatorController[] animatorControllers;
    [SerializeField] private CharAnimController charAnimController;
    [SerializeField] private float moveSpeed = 10;

    private Rigidbody2D rb;
    private float xInput;
    private float screenLx, screenRx;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public GameObject TouchingStep { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        SelectAnimatorController();
        SetScreenLR();
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
    void SelectAnimatorController(){
        if (MenuSystem.charSkin == CharSkin.Boy){
            animator.runtimeAnimatorController = animatorControllers[0];
        } else if (MenuSystem.charSkin == CharSkin.Girl) {
            animator.runtimeAnimatorController = animatorControllers[1];
        }
    }

    void SetScreenLR(){
        screenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLx = -screenRx;
    }

    void InitCharGravity(float gravity){
        // Character Gravity Init
        if (rb.gravityScale == 0)
        {
            rb.gravityScale = gravity;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (rb.velocity.y > -0.01) {
            charAnimController.ChangeState(charAnimStates[0]); //IDLE
        }
        if (other.collider.CompareTag("Step")){
            TouchingStep = other.collider.gameObject;
        }
    }

    void AnimationStateController()
    {   
        if (rb.velocity.y < -0.5) { 
            charAnimController.ChangeState(charAnimStates[5]); // StartFalling
            return; // If char falling physically, no change allowed
        }
        if (xInput < 0) {
            charAnimController.ChangeState(charAnimStates[1]); //LEFT
        } else if (xInput > 0) {
            charAnimController.ChangeState(charAnimStates[2]); //RIGHT
        } else {
            charAnimController.ChangeState(charAnimStates[0]); //IDLE
        }
    }

    void Movement()
    {
        xInput = joystick.Horizontal;
        transform.position += new Vector3(xInput * moveSpeed * Time.fixedDeltaTime, 0, 0);
        
        // Character Warpping
        if (transform.position.x < screenLx)
        {
            transform.position = new Vector3(screenRx, transform.position.y, transform.position.z);
        } else if (transform.position.x > screenRx)
        {
            transform.position = new Vector3(screenLx, transform.position.y, transform.position.z);
        }
    }

    void CheckCharSurvive(){
        // When character touching bottom
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            // SceneManager.LoadScene(3);
        }
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