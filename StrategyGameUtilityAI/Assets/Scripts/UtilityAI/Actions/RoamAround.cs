using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move randomly around
/// </summary>
public class RoamAround : UtilityAction
{
    private float timer;
    private float interval;


    public RoamAround(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public RoamAround(float roamingInterval, UtilityAgent agent, float initialScore) : base(agent, initialScore) 
    {
        interval = roamingInterval;
    }

    public override void Execute()
    {
        base.Execute();

        timer += Time.deltaTime;

        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < 0.5f)
        {
            // Should the agent wait before it searches for a new destination?
            if (timer < interval) return;
            timer = 0;

            Vector3 agentPos = _agent.transform.position;
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            _agent._AgentController._NavAgent.destination = agentPos + randomPos;
        }
    }
}