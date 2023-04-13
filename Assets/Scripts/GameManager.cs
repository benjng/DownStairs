using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameMode {
        Simple,
        Normal
    }
    public static GameMode gameMode = GameMode.Normal;

    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void StartSimpleGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartNormalGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.buildIndex == 1){
            gameMode = GameMode.Simple;
            return;
        }
        if (scene.buildIndex == 2){
            gameMode = GameMode.Normal;
            return;
        }
    }
}