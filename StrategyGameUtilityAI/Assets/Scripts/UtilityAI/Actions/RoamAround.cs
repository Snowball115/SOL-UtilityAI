using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move randomly around
/// </summary>
public class RoamAround : UtilityAction
{
    private float timer;
    private float roamingTimer;

    public RoamAround(float roamingInterval, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        // Agent should instantly start moving
        timer = 0.2f;

        // How fast is the agent searching for a new location
        roamingTimer = roamingInterval;
    }

    public override void Execute()
    {
        base.Execute();

        timer += Time.deltaTime;

        if (timer > roamingTimer)
        {
            Vector3 agentPos = _agent.transform.position;
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            _agent._AgentController._NavAgent.destination = agentPos + randomPos;
            timer = 0;
        }
    }
}