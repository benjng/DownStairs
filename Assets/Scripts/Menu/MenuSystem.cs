using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    public enum Skin{
        Boy,
        Girl
    }
    public Skin currentSkin;

    public void SetBoySkin(){
        currentSkin = Skin.Boy;
    }
    public void SetGirlSkin(){
        currentSkin = Skin.Girl;
    }
}