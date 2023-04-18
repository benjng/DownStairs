using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    #region Game Parameters
    public enum Skin{ Boy, Girl }
    public Skin gameSkin;
    public static GameMode gameMode;
    #endregion
    
    [SerializeField] private MenuState currentState;

    void Awake(){
        currentState.Enter(); // Init state
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