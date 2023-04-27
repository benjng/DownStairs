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
            scoreRows[i].transform.Find("pName").GetComponent<TextMeshPro>().text = PlayerPrefs.GetString("Rank_"+ i.ToString() + "_Name");
            scoreRows[i].transform.Find("pFloor").GetComponent<TextMeshPro>().text = PlayerPrefs.GetInt("Rank_"+ i.ToString() + "_Floor").ToString();
        }
    }


}
