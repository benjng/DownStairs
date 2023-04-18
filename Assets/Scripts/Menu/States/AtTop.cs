using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtTop : MenuState
{
    public override void Enter()
    {
        gameObject.SetActive(true);
    }

    public override void Exit()
    {
        gameObject.SetActive(false);
    }
}
