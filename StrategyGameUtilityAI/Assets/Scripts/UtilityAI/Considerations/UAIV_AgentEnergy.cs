using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAIV_AgentEnergy : UtilityValue
{
    public UAIV_AgentEnergy(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._AgentData.Energy;
    }
}
