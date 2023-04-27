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
        StartCoroutine(ActivateRetryBtn());
        currentPlayer.text = PlayerPrefs.GetString("CurrentPlayer");
        coinCount.text = "+ " + PlayerPrefs.GetInt("CurrentCoinCount", 9999).ToString();
        floorCount.text = PlayerPrefs.GetInt("CurrentFloorCount", 9999).ToString() + "/F";
    }

    // TODO: Add player info to leaderboard
    

    // Retry btn function
    IEnumerator ActivateRetryBtn(){
        retryBtn.interactable = false;
        yield return new WaitForSeconds(1);
        retryBtn.interactable = true;
        retryBtn.onClick.AddListener(Reset);
    }

    // Retry btn ref
    void Reset(){
        LevelLoader.instance.ResetToMainMenu();
    }
}
