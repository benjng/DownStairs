using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityList : MonoBehaviour
{
    #region Singleton

    // Only One single list in game
    public static AbilityList instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of AbilityList found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void AbilityChangedEventHandler();
    public event AbilityChangedEventHandler OnAbilityChanged;

    public void AddAbility()
    {

    }

    public void RemoveAbility()
    {

    }
}
