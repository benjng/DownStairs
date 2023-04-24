using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatusBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // int implmentation
    public virtual void SetMaxValue(int value){
        slider.maxValue = value;
        // slider.value = value;
        fill.color = gradient.Evaluate(1f);
    }
    public virtual void SetValue(int value){
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // float implmentation
    public virtual void SetMaxValue(float value){
        slider.maxValue = value;
        // slider.value = value;
        fill.color = gradient.Evaluate(1f);
    }
    public virtual void SetValue(float value){
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
