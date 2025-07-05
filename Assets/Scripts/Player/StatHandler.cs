using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler 
{

    public float Add(float currentValue, float value)
    {
        float result = currentValue + value;
        return result;
    }

    public float Sub(float currentValue, float value)
    {
        return Mathf.Max(currentValue - value, 0); 
    }

}
