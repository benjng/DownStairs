using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : StatusBar
{
    public override void SetMaxValue(int maxHealth){
        base.SetMaxValue(maxHealth);
    }

    public override void SetValue(int health){
        base.SetValue(health);
    }
}
