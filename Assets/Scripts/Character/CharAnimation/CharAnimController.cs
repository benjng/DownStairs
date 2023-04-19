using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimController : MonoBehaviour
{
    [SerializeField] private CharAnimState currentState;
    private Rigidbody2D charRb;

    void Awake(){
        currentState.Enter(); // Init Animation state
        charRb = GetComponent<Rigidbody2D>();
    }

    public bool CheckState(){
        if (charRb.velocity.y < -0.5) { // If char falling physically
            return false; // no change allowed
        }
        return true;
    }

    // Change state
    public void ChangeState(CharAnimState newState){ 
        if (currentState != null && CheckState()){ // exit currentState
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
}
