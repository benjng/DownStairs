using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistAtkRight : CharAnimState
{
    public override void Enter()
    {
        animator.SetTrigger("fistAtkRight");
    }

    public override void Exit()
    {
        
    }
}
