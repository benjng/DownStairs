using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;
    public static List<KeyValuePair<string, int>> SortedRanks = new List<KeyValuePair<string, int>>();

    void Awake()
	{
        // Singleton
		if (instance != null) {
			Destroy(gameObject);
            return;
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

        // Should call once only for ScoreBoard INIT
        // ScoreRow format in PlayerPrefs: Rank_1_Name(string): Rank_1_Floor(int)
        for (int i=1; i<6; i++){
            // Get data from PlayerPrefs
            KeyValuePair<string, int> playerInfo = new KeyValuePair<string, int>(PlayerPrefs.GetString("Rank_"+i.ToString()+"_Name"), PlayerPrefs.GetInt("Rank_"+i.ToString()+"_Floor", 5-i));
            // Init SortedRanks for future updates
            SortedRanks.Add(playerInfo); 
        }

        // Sort the rank before ScoreBoard renders
        SortedRanks.Sort((x, y) => y.Value.CompareTo(x.Value));
        
        // Debug.Log("Pre-game SortedRanks: ");
        // // Print the sorted list
        // foreach (KeyValuePair<string, int> kvp in SortedRanks)
        // {
        //     Debug.Log(kvp.Key + " - " + kvp.Value);
        // }
    }
}
