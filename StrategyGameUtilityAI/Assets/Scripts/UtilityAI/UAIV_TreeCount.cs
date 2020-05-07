using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAIV_TreeCount : UtilityValue
{
    public UAIV_TreeCount(UtilityAgent agent) : base(agent) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._Senses.CountObjectsInSight(GameCache._GameCache.GetData("Tree"));
    }
}
