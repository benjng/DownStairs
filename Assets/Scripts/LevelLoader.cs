using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void StartGame()
    {
        if (MenuSystem.gameMode == GameMode.Simple){
            StartCoroutine(LoadLevel(1));
            return;
        } 
        if (MenuSystem.gameMode == GameMode.Normal){
            StartCoroutine(LoadLevel(2));
            return;
        }
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.buildIndex == 1){
            return;
        }
        if (scene.buildIndex == 2){
            return;
        }
        if (scene.buildIndex == 3){
            return;
        }
    }

    public void ResetToMainMenu(){
        StartCoroutine(LoadLevel(0));
    }
}