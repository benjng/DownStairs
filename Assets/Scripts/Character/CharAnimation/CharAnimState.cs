using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharAnimState : MonoBehaviour
{
    public Animator animator;
    private Character character;
    
    void Awake(){
        character = FindObjectOfType<Character>();
        animator = character.GetComponent<Animator>();
    }
    public abstract void Enter();
    public abstract void Exit();
}
