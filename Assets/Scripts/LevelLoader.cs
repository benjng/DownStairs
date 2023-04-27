using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    void InitNameField(){
        currentPlayer = PlayerPrefs.GetString("CurrentPlayer", playerNamePH.text);
        Debug.Log("PP CurrentPlayer: "+currentPlayer);
        playerInputField.text = currentPlayer; // Init StartMenu name field 
    }

    void InitAndSavePlayerInfo(){
        currentPlayer = playerInputField.text;
        PlayerPrefs.SetString("CurrentPlayer", currentPlayer);
        PlayerPrefs.SetInt("CurrentCoinCount", 0);
        PlayerPrefs.SetInt("CurrentFloorCount", 0);
        PlayerPrefs.Save();
    }

    // StartBtn ref
    public void StartGame()
    {   
        InitAndSavePlayerInfo();
        StartCoroutine(LoadLevel(1));
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
            Debug.Log("Loaded scene[0]: StartMenu");
            return;
        }
        if (scene.buildIndex == 1){
            Debug.Log("Loaded scene[1]: Normal");
            return;
        }
        if (scene.buildIndex == 2){ // End Menu
            Debug.Log("Loaded scene[2]: EndMenu");
            return;
        }
    }

    public void OnPlayerDeath(){
        GameCounter.GameStarted = false;
        StartCoroutine(LoadLevel(2));
    }

    public void ResetToMainMenu(){
        StartCoroutine(LoadLevel(0));
    }
}