using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightBar : StatusBar
{
    public override void SetMaxValue(int maxWeight){
        base.SetMaxValue(maxWeight);
    }

    public override void SetValue(int weight){
        base.SetValue(weight);
    }
}
