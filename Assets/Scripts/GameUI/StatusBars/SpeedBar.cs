using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : StatusBar
{
    public override void SetMaxValue(float maxSpeed){
        base.SetMaxValue(maxSpeed);
    }

    public override void SetValue(float speed){
        base.SetValue(speed);
    }
}
