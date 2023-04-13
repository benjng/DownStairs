using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartSimpleGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartNormalGame()
    {
        SceneManager.LoadScene(2);
    }
}