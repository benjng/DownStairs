using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuState : MonoBehaviour
{
    public abstract void Enter();
    public abstract void Exit();
}
