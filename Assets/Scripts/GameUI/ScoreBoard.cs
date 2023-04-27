using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ScoreBoard rendering only (no sorting logics)
public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject[] scoreRows;

    // New ScoreBoard each time entering StartMenu
    void Start(){
        int i = 0;
        // Load all current sorted SortedRanks data into the scoreboard
        foreach (KeyValuePair<string, int> pair in ScoreKeeper.SortedRanks)
        {
            string playerName = pair.Key;
            int playerScore = pair.Value;
            scoreRows[i].transform.Find("pName").GetComponent<TMP_Text>().text = playerName;
            scoreRows[i].transform.Find("pFloor").GetComponent<TMP_Text>().text = playerScore.ToString();
            i++;
            if (i >= 5) break; // Render only top 5 from sorted SortedRanks
        }
    }
}
