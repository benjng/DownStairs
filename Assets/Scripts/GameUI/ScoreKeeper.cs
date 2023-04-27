using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    #region Singleton
    public static ScoreKeeper instance;
    void Awake()
	{
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
    #endregion

    public static Dictionary<string, int> ranks = new Dictionary<string, int>();
    void Start() {
        // Load all PlayerPrefs data into the dictionary
        for (int i=0; i<5; i++){
            ranks.Add(PlayerPrefs.GetString("Rank_"+i.ToString()+"_Name"), PlayerPrefs.GetInt("Rank_"+i.ToString()+"_Floor", 5-i));
        }
    }

    void Update()
    {
        
    }
}
