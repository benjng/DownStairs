using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public enum GameMode {
        Simple,
        Normal
    }
    public static GameMode gameMode = GameMode.Normal;
    public Animator transition;
    public float transitionTime = 1f;

    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void StartSimpleGame()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void StartNormalGame()
    {
        StartCoroutine(LoadLevel(2));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
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