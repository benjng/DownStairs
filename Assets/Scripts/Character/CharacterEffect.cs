using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffect : MonoBehaviour
{
    #region Singleton
    public static CharacterEffect instance;
    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicated CharacterEffect instance found.");
            return;
        }
        instance = this;
    }
    #endregion
    public Animator animator;

    public void PlayEffect(CharEffect effect){
        animator.SetTrigger(effect.ToString());
    }
}
