using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public CharAnimState[] charAnimStates;

    [SerializeField] private Animator animator;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private RuntimeAnimatorController[] animatorControllers;
    [SerializeField] private CharAnimController charAnimController;
    [SerializeField] private CharacterStatus charStatus;


    private Rigidbody2D rb;
    private float xInput;
    private float screenLx, screenRx;
    public GameObject TouchingStep { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SelectAnimatorController();
        SetScreenLR();
    }

    void FixedUpdate()
    {
        // Check if game has started by UI counter
        if (!GameCounter.GameStarted) return;

        AnimationStateController();
        Movement();
        CheckCharSurvive();
    }

    void SelectAnimatorController(){
        if (SkinManager.charSkin == CharSkin.Boy){
            animator.runtimeAnimatorController = animatorControllers[0];
        } else if (SkinManager.charSkin == CharSkin.Girl) {
            animator.runtimeAnimatorController = animatorControllers[1];
        } else if (SkinManager.charSkin == CharSkin.Baby) {
            animator.runtimeAnimatorController = animatorControllers[2];
        }
    }

    void SetScreenLR(){
        screenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLx = -screenRx;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (rb.velocity.y > -0.01) {
            charAnimController.ChangeState(charAnimStates[0]); //IDLE
        }
        
        // For spike Step removal sensing
        if (collision.collider.CompareTag("Step") || collision.collider.CompareTag("ExtraStep") || collision.collider.CompareTag("RemoteStep")){
            if (Random.value > 0.4){
                AudioManager.instance.Play("HitConcreteStep1");
            } else {
                AudioManager.instance.Play("HitConcreteStep2");
            }
            collision.collider.tag = "TouchingStep";
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
        transform.position += new Vector3(xInput * charStatus.MoveSpeed * Time.fixedDeltaTime, 0, 0);
        
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