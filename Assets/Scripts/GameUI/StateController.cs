using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum Skin{
        Boy,
        Girl
    }
    public Skin currentSkin;

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    public void SetBoySkin(){
        currentSkin = Skin.Boy;
    }
    public void SetGirlSkin(){
        currentSkin = Skin.Girl;
    }
}