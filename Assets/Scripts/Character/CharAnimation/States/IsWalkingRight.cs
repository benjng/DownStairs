using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWalkingRight : CharAnimState
{
    public override void Enter()
    {
        animator.SetBool("isWalkingRight", true);
    }

    public override void Exit()
    {
        animator.SetBool("isWalkingRight", false);
    }
}
