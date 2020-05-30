using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Heal agent at friendly flag action
/// </summary>
public class HealAtFlag : UtilityAction
{
    private GameObject closestFlag;
    private GameObject flagPrefab;
    private float distanceToHeal = 5.0f;


    public HealAtFlag(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        _agent._AgentController._NavAgent.autoBraking = true;

        _agent._AgentController._NavAgent.stoppingDistance = 0.0f;

        flagPrefab = GameCache._Cache.GetData("CapturePoint");
    }

    public override void Execute()
    {
        base.Execute();

        // Check if a flag is near
        if (_agent._AgentController._Senses.ContainsObject(flagPrefab))
        {
            closestFlag = _agent._AgentController._Senses.GetClosestObject(flagPrefab);

            // Check if flag is your own
            if (closestFlag.GetComponent<CapturePoint>()._TeamOwner == _agent._AgentController._PlayerOwner)
            {
                float distance = (closestFlag.transform.position - _agent.transform.position).sqrMagnitude;

                _agent._AgentController._NavAgent.destination = closestFlag.transform.position;

                // Check if in distance to heal
                if (distance < distanceToHeal)
                {
                    _agent._AgentController.Heal();
                }
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        _agent._AgentController._NavAgent.autoBraking = false;
    }
}
