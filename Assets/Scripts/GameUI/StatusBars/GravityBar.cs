using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityBar : StatusBar
{
    public override void SetMaxValue(float maxGravity){
        base.SetMaxValue(maxGravity);
    }

    public override void SetValue(float gravity){
        base.SetValue(gravity);
    }
}
