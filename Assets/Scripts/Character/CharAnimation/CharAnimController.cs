using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimController : MonoBehaviour
{
    [SerializeField] private CharAnimState currentState;

    void Awake(){
        currentState.Enter(); // Init Animation state
    }

    // void ChangeState(CharAnimState newState){
    //     if (currentState != null){ // exit currentState
    //         currentState.Exit();
    //     }
    //     currentState = newState;
    //     currentState.Enter();
    // }

    // State Control
    public void ChangeState(CharAnimState newState){ 
        if (currentState == newState) return;

        if (currentState != null){ // exit currentState
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }
}
