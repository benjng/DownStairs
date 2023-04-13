using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameMode {
        Simple,
        Normal
    }
    public static GameMode gameMode = GameMode.Simple;
    public void StartSimpleGame()
    {
        gameMode = GameMode.Simple;
        SceneManager.LoadScene(2);
    }
    public void StartNormalGame()
    {
        gameMode = GameMode.Normal;
        SceneManager.LoadScene(3);
    }
}