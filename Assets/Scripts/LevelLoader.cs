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

    // OnDestroy(){ SceneManager.sceneLoaded -= OnSceneLoaded; }
    void Start(){
        InitNameField();
    }

    void InitNameField(){
        currentPlayer = PlayerPrefs.GetString("CurrentPlayer", playerNamePH.text);
        Debug.Log(currentPlayer);
        playerInputField.text = currentPlayer; // Init StartMenu name field 
    }

    // StartBtn ref
    public void StartGame()
    {   
        currentPlayer = playerInputField.text;
        PlayerPrefs.SetString("CurrentPlayer", currentPlayer);
        PlayerPrefs.Save();

        StartCoroutine(LoadLevel(1));
    }

    public IEnumerator LoadLevel(int levelIndex){
        // Transition animation
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("FadeIn");

        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
        
        // renew LevelLoader cycle
        if (levelIndex == 0){ 
            Destroy(gameObject);
            instance = null;
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.buildIndex == 0){
            // Debug.Log("StartMenu");
            return;
        }
        if (scene.buildIndex == 1){
            // Debug.Log("Game");
            return;
        }
        if (scene.buildIndex == 2){ // End Menu
            // Debug.Log("EndMenu");
            Debug.Log("EndMenu Player: "+PlayerPrefs.GetString("CurrentPlayer"));
            return;
        }
    }

    public void ResetToMainMenu(){
        GameCounter.GameStarted = false;
        StartCoroutine(LoadLevel(0));
    }
}