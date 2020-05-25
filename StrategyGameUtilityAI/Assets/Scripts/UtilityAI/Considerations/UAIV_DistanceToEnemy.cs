using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAIV_DistanceToEnemy : UtilityValue
{
    private GameObject closestEnemy;


    public UAIV_DistanceToEnemy(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        if (_agent._AgentController._Senses.ContainsEnemyInSight())
        {
            closestEnemy = _agent._AgentController._Senses.GetClosestEnemy();

            _CurrentValue = (closestEnemy.transform.position - _agent.transform.position).sqrMagnitude;
        }
        else
        {
            _CurrentValue = _MaxValue;
        }
    }
}
