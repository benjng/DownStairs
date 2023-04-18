using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtTop : MenuState
{
    public override void Enter()
    {
        Debug.Log("Entering Top Menu");
        gameObject.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Top Menu");
        gameObject.SetActive(false);
    }
}
