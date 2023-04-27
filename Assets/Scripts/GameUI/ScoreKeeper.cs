using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;
    public static Dictionary<string, int> Ranks = new Dictionary<string, int>();

    void Awake()
	{
        // Singleton
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

        // Load all existing PlayerPrefs data into the dictionary
        // ScoreRow format in PlayerPrefs:
        // Rank_1_Name(string): Rank_1_Floor(int)
        for (int i=0; i<5; i++){
            Ranks.Add(PlayerPrefs.GetString("Rank_"+i.ToString()+"_Name"), PlayerPrefs.GetInt("Rank_"+i.ToString()+"_Floor", 5-i));
        }

        // TODO: Sort the rank before ScoreBoard renders
        
	}
}
