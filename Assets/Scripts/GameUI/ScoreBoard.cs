using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject[] scoreRows;
    void Start(){
        // Load all current ORDERED PlayerPrefs data into the scoreboard
        for (int i=0; i<5; i++){
            // Debug.Log(scoreRows[i].transform.Find("pName").GetComponent<TMP_Text>().text);
            scoreRows[i].transform.Find("pName").GetComponent<TMP_Text>().text = PlayerPrefs.GetString("Rank_"+i.ToString()+"_Name", "rank"+(i+1)+"_player");
            scoreRows[i].transform.Find("pFloor").GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Rank_"+i.ToString()+"_Floor", 5-i).ToString();
        }
    }
}
