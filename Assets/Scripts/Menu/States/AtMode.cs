using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtMode : MenuState
{
    public override void Enter()
    {
        Debug.Log("Entering Mode Menu");
        gameObject.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Mode Menu");
        gameObject.SetActive(false);
    }
}
