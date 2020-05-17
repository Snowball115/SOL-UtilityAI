using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check if mine is placed or not
/// </summary>
public class UAIV_LumberyardPlaced : UtilityValue
{
    private Lumberjack agent;


    public UAIV_LumberyardPlaced(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue)
    {
        this.agent = agent.GetComponent<Lumberjack>();
    }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = agent.isLumberyardPlaced ? 1 : 0;
    }
}
