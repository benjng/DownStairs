using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunBar : StatusBar
{
    public override void SetMaxValue(int maxSpeed){
        base.SetMaxValue(maxSpeed);
    }

    public override void SetValue(int speed){
        base.SetValue(speed);
    }
}
