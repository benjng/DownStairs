using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameMode {
        Simple,
        Normal
    }
    public static GameMode gameMode;
    public void StartSimpleGame()
    {
        gameMode = GameMode.Simple;
        SceneManager.LoadScene(1);
    }
    public void StartNormalGame()
    {
        gameMode = GameMode.Normal;
        SceneManager.LoadScene(2);
    }
}