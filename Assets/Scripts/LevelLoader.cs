using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    #region Singleton
        public static LevelLoader instance;
    #endregion

    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] private TMP_InputField playerInputField;
    // [SerializeField] private TMP_Text playerInput;
    [SerializeField] private TMP_Text playerNamePH;
    private string currentPlayer;

    void Awake(){
        Debug.Log(Screen.currentResolution.refreshRate);
        Application.targetFrameRate = 60;

        // PlayerPrefs.DeleteAll();
        if (instance != null){
            Debug.LogWarning("Duplicated LevelLoader instance found.");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start(){
        InitNameField();
    }

    void OnDestroy(){ SceneManager.sceneLoaded -= OnSceneLoaded; }

    // StartBtn ref
    public void StartGame()
    {   
        InitAndSavePlayerInfo();
        StartCoroutine(LoadLevel(1));
    }
    
    void InitNameField(){
        currentPlayer = PlayerPrefs.GetString("CurrentPlayer", playerNamePH.text);
        Debug.Log("PlayerPrefs CurrentPlayer: "+currentPlayer);
        playerInputField.text = currentPlayer; // Init StartMenu name field 
    }

    void InitAndSavePlayerInfo(){
        currentPlayer = playerInputField.text;
        PlayerPrefs.SetString("CurrentPlayer", currentPlayer);
        PlayerPrefs.SetInt("CurrentCoinCount", 0);
        PlayerPrefs.SetInt("CurrentFloorCount", 0);
        PlayerPrefs.Save();
    }

    public IEnumerator LoadLevel(int levelIndex){
        // Transition animation
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("FadeIn");

        // Load level
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);

        // If loading into StartMenu(0), destroy self for next levelloader
        if (levelIndex == 0){ 
            Destroy(gameObject);
            instance = null;
            Debug.Log("Current LevelLoader destroyed");
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.buildIndex == 0){
            // Debug.Log("Loaded scene[0]: StartMenu");
            return;
        }
        if (scene.buildIndex == 1){
            // Debug.Log("Loaded scene[1]: Normal");
            return;
        }
        if (scene.buildIndex == 2){ // End Menu
            // Debug.Log("Loaded scene[2]: EndMenu");
            return;
        }
    }

    public void OnPlayerDeath(){
        GameCounter.GameStarted = false;
        AudioManager.instance.Play("OnDeathScream");
        PlayerPrefs.SetInt("CurrentFloorCount", StepsSpawner.CurrentFloor);
        RankCurrentPlayer();
        StartCoroutine(LoadLevel(2));
    }
    void RankCurrentPlayer(){
        // Add current player to SortedRanks for order check
        KeyValuePair<string, int> currentPlayer = new KeyValuePair<string, int>(PlayerPrefs.GetString("CurrentPlayer"), PlayerPrefs.GetInt("CurrentFloorCount"));
        ScoreKeeper.SortedRanks.Add(currentPlayer);
        ScoreKeeper.SortedRanks.Sort((x, y) => y.Value.CompareTo(x.Value));

        // Update PlayerPrefs with the SortedRanks & SAVE it
        int i=1;
        foreach (KeyValuePair<string, int> pair in ScoreKeeper.SortedRanks)
        {
            
            string playerName = pair.Key;
            int playerScore = pair.Value;
            PlayerPrefs.SetString("Rank_"+i.ToString()+"_Name", playerName);
            PlayerPrefs.SetInt("Rank_"+i.ToString()+"_Floor", playerScore);
            i++;
            if (i >= 6) break; // Retrieve top 5 from sorted SortedRanks
        } 
        PlayerPrefs.Save();
    }

    public void ResetToMainMenu(){
        StartCoroutine(LoadLevel(0));
    }
}