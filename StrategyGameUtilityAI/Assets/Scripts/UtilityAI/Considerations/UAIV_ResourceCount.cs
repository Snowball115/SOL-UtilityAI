using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Count a specific resource in the agents surrounding
/// </summary>
public class UAIV_ResourceCount : UtilityValue
{
    private readonly string objectTag;


    public UAIV_ResourceCount(string objectTag, UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue)
    {
        this.objectTag = objectTag;
    }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._Senses.CountObjectsInSight_ByTag(GameCache._Cache.GetData(objectTag));
    }
}