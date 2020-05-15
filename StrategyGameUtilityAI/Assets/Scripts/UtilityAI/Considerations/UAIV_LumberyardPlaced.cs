using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check if a bool is true or not
/// </summary>
public class UAIV_BoolCheck : UtilityValue
{
    private bool boolToCheck;


    public UAIV_BoolCheck(bool boolToCheck, UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue)
    {
        this.boolToCheck = boolToCheck;
    }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = Convert.ToInt16(boolToCheck);
    }
}
