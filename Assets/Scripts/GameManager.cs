using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameMode {
        Simple,
        Normal
    }
    public static GameMode gameMode = GameMode.Normal;
    public void StartSimpleGame()
    {
        gameMode = GameMode.Simple;
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    public void StartNormalGame()
    {
        gameMode = GameMode.Normal;
        SceneManager.LoadScene(3);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}