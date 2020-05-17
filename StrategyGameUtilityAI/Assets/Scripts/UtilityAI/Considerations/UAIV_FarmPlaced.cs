using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check if farm is placed or not
/// </summary>
public class UAIV_FarmPlaced : UtilityValue
{
    private Farmer agent;


    public UAIV_FarmPlaced(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue)
    {
        this.agent = agent.GetComponent<Farmer>();
    }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = agent.isFarmPlaced ? 1 : 0;
    }
}
