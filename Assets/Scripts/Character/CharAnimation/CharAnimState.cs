using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class CharAnimState : MonoBehaviour
{
    public Animator animator;
    private int sceneIndex;
    // private Character character;
    
    void Awake(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start(){
        if (sceneIndex == 0){
            animator = FindObjectOfType<MenuCharacter>().GetComponent<Animator>();
            return;
        }
        animator = FindObjectOfType<Character>().GetComponent<Animator>();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        sceneIndex = scene.buildIndex;
    }

    public abstract void Enter();
    public abstract void Exit();
}
