using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Get enemy soldiers in surrounding count
/// </summary>
public class UAIV_SoldierEnemyCount : UtilityValue
{
    public UAIV_SoldierEnemyCount(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._Senses.CountEnemySoldiersInSight();
    }
}
