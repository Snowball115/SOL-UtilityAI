using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAIV_SoldierFriendlyCount : UtilityValue
{
    public UAIV_SoldierFriendlyCount(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._Senses.CountFriendlySoldiersInSight();
    }
}
