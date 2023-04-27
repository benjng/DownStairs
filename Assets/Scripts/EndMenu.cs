using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Button retryBtn;
    [SerializeField] private TMP_InputField currentPlayer;
    [SerializeField] private TMP_Text coinCount;
    [SerializeField] private TMP_Text floorCount;
    void Start()
    {
        retryBtn.onClick.AddListener(Reset);
        currentPlayer.text = PlayerPrefs.GetString("CurrentPlayer");
        coinCount.text = PlayerPrefs.GetString("CurrentCoinCount", "9999c");
        floorCount.text = PlayerPrefs.GetString("CurrentFloorCount", "9999f");
    }

    // TODO: Add player info to leaderboard

    void Reset(){
        LevelLoader.instance.ResetToMainMenu();
    }
}
