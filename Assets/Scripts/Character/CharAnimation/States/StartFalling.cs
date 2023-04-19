using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFalling : CharAnimState
{
    public override void Enter()
    {
        animator.SetTrigger("startFalling");
    }

    public override void Exit()
    {
        // Debug.Log("Exitting startFalling");
    }
}
