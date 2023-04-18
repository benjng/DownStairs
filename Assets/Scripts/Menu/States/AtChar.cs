using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtChar : MenuState
{
    public override void Enter()
    {
        Debug.Log("Entering Char Menu");
        gameObject.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Char Menu");
        gameObject.SetActive(false);
    }
}
