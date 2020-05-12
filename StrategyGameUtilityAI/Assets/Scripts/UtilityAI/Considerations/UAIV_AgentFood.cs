using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAIV_AgentFood : UtilityValue
{
    public UAIV_AgentFood(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._Food;
    }
}
