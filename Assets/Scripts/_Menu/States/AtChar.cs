using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtChar : MenuState
{
    [SerializeField] private Button boyBtn;
    [SerializeField] private Button girlBtn;

    public override void Enter()
    {
        gameObject.SetActive(true);
    }

    public override void Exit()
    {
        gameObject.SetActive(false);
    }

    void Start(){
        boyBtn.onClick.AddListener(OnBoyClicked);
        girlBtn.onClick.AddListener(OnGirlClicked);
    }

    void OnBoyClicked(){
        SkinManager.charSkin = CharSkin.Boy;
    }
    void OnGirlClicked(){
        SkinManager.charSkin = CharSkin.Girl;
    }
}
