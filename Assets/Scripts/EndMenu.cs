using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button retryBtn;
    [SerializeField] private TMP_InputField currentPlayer;
    void Start()
    {
        retryBtn.onClick.AddListener(Reset);
        currentPlayer.text = PlayerPrefs.GetString("CurrentPlayer");
    }

    // TODO: Add player info to leaderboard

    void Reset(){
        LevelLoader.instance.ResetToMainMenu();
    }
}
