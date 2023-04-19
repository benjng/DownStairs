using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWalkingLeft : CharAnimState
{
    public override void Enter()
    {
        animator.SetBool("isWalkingLeft", true);
    }

    public override void Exit()
    {
        animator.SetBool("isWalkingLeft", false);
    }
}
