using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsIdle : CharAnimState
{
    public override void Enter()
    {
        animator.SetBool("isIdle", true);
    }

    public override void Exit()
    {
        animator.SetBool("isIdle", false);
    }
}
