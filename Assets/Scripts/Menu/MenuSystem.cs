using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    #region Game Parameters
    public enum Skin{ Boy, Girl }
    public enum Mode{ Simple, Normal }
    public Skin gameSkin;
    public Mode gameMode;
    #endregion
    
    [SerializeField] private MenuState currentState;

    void Awake(){
        currentState.Enter();
    }

    // Change state
    public void ChangeState(MenuState newState){ 
        if (currentState != null){ // exit currentState if exists
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
}