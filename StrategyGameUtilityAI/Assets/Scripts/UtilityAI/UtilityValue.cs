using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UtilityValue
{
    // Name in editor
    public string Name;

    // Max value of our input on the x-axis of the animation curve
    public float _MaxValue;

    // The current value of our input
    public float _CurrentValue;

    // The agent where the input can get information from
    protected UtilityAgent _agent;


    public UtilityValue(UtilityAgent agent, float maxInputValue)
    {
        _agent = agent;
        _MaxValue = maxInputValue;
    }

    public virtual void UpdateCurrentValue() { }
}