using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacter : MonoBehaviour
{
    public CharAnimState[] charAnimStates;
    [SerializeField] private Animator animator;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private CharAnimController charAnimController;
    [SerializeField] private RuntimeAnimatorController[] animatorControllers;
    [SerializeField] private float moveSpeed;
    private float xInput;
    private float screenLx, screenRx;
    
    [SerializeField] private int currentACIndex = 0;


    void Start()
    {
        SelectAnimatorController(0);
        SetScreenLR();
    }

    void SetScreenLR(){
        screenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLx = -screenRx;
    }
    void AnimationStateController(){
        if (xInput < 0) {
            charAnimController.ChangeState(charAnimStates[1]); //LEFT
        } else if (xInput > 0) {
            charAnimController.ChangeState(charAnimStates[2]); //RIGHT
        } else {
            charAnimController.ChangeState(charAnimStates[0]); //IDLE
        }
    }
    void SelectAnimatorController(int index){
        animator.runtimeAnimatorController = animatorControllers[index]; // [0]:Boy controller [1]:Girl controller
    }
    
    void Movement()
    {
        xInput = joystick.Horizontal;
        transform.position += new Vector3(xInput * moveSpeed * Time.fixedDeltaTime, 0, 0);
        
        // Character Warpping
        if (transform.position.x < screenLx){
            transform.position = new Vector3(screenRx, transform.position.y, transform.position.z);
            currentACIndex++;
            if (currentACIndex > animatorControllers.Length-1)
                currentACIndex = 0;
        } else if (transform.position.x > screenRx){
            transform.position = new Vector3(screenLx, transform.position.y, transform.position.z);
            currentACIndex--;
            if (currentACIndex < 0) 
                currentACIndex = animatorControllers.Length-1;
        } else return;
        SelectAnimatorController(currentACIndex);
        SkinManager.charSkin = (CharSkin)currentACIndex;
    }

    void FixedUpdate(){
        Movement();
        AnimationStateController();
    }
}
