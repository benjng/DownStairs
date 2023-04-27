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
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text playerNamePH;
    [SerializeField] private GameObject retryBtn;
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
        // Debug.Log("Current Player: "+ PlayerPrefs.GetString("CurrentPlayer"));
        if (PlayerPrefs.HasKey("CurrentPlayer")){
            currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
            playerNamePH.text = currentPlayer;
        } else {
            playerNamePH.text = "testing";
        }
    }

    // StartBtn ref
    public void StartGame()
    {   
        if (playerName.text != null){
            PlayerPrefs.SetString("CurrentPlayer", playerName.text);
        } else {
            PlayerPrefs.SetString("CurrentPlayer", playerNamePH.text);
        }
        PlayerPrefs.Save();

        StartCoroutine(LoadLevel(1));
    }

    public IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("FadeIn");
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
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
            Debug.Log(PlayerPrefs.GetString("CurrentPlayer"));
            return;
        }
    }

    public void ResetToMainMenu(){
        GameCounter.GameStarted = false;
        StartCoroutine(LoadLevel(0));
    }
}