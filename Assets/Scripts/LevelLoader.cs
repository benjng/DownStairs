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
            Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        // Debug.Log("Has current Player: "+ PlayerPrefs.HasKey("CurrentPlayer"));
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start(){
        // Debug.Log("Current Player: "+ PlayerPrefs.GetString("CurrentPlayer"));
        if (PlayerPrefs.HasKey("CurrentPlayer")){
            currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
            playerNamePH.text = currentPlayer;
        } else {
            playerNamePH.text = "???";
        }
    }

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
        GameStarter.gameStarted = false;
        StartCoroutine(LoadLevel(0));
    }
}