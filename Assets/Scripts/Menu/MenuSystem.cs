using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuSystem : MonoBehaviour
{
    #region Game Parameters
    public static CharSkin charSkin;
    public static GameMode gameMode;
    #endregion
    
    [SerializeField] private TMP_Text gameModeText;
    [SerializeField] private MenuState currentState;

    void Awake(){
        currentState.Enter(); // Init state
        gameModeText.text = gameMode.ToString();
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