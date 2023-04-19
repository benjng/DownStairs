using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistAtkLeft : CharAnimState
{
    public override void Enter()
    {
        animator.SetTrigger("fistAtkLeft");
    }

    public override void Exit()
    {
        
    }
}
