using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterData
{
    public string ID { get; }

    public float ValueForRefence { get; }
    
    public float CurrentValue { get; private set; }

    public bool IsEnabled { get; set; }

    public CounterData(string id, float valueForRefence)
    {
        ID = id;
        IsEnabled = false;
        ValueForRefence = valueForRefence;
        CurrentValue = 0f;
        Debug.Log("New counter added with id: " + ID);
    }

    public void AddToCurrentValue(float valueToAdd)
    {
        CurrentValue += valueToAdd;
//        Debug.Log("Counter " + ID + ": " + CurrentValue);
    }
    
}
