using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtMode : MenuState
{
    [SerializeField] private Button simpleBtn;
    [SerializeField] private Button normalBtn;

    public override void Enter()
    {
        gameObject.SetActive(true);
    }

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    void Start(){
        simpleBtn.onClick.AddListener(OnSimpleClicked);
        normalBtn.onClick.AddListener(OnNormalClicked);
    }

    void OnSimpleClicked(){
        MenuSystem.gameMode = GameMode.Simple;
    }
    void OnNormalClicked(){
        MenuSystem.gameMode = GameMode.Normal;
    }
}
