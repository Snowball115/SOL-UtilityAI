using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check if lumberyard is placed or not
/// </summary>
public class UAIV_MinePlaced : UtilityValue
{
    private Miner agent;


    public UAIV_MinePlaced(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue)
    {
        this.agent = agent.GetComponent<Miner>();
    }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = agent.isMinePlaced ? 1 : 0;
    }
}
