using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button retryBtn;
    void Start()
    {
        retryBtn.onClick.AddListener(Reset);
    }

    void Reset(){
        LevelLoader.instance.ResetToMainMenu();
    }
}
