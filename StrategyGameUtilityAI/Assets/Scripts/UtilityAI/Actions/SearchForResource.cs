using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Search for a resource
/// </summary>
public class SearchForResource : UtilityAction
{
    private string targetName;


    public SearchForResource(string targetName, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.targetName = targetName;
    }

    public override void Execute()
    {
        base.Execute();

        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < 0.5f)
        {
            Vector3 agentPos = _agent.transform.position;
            Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            _agent._AgentController._NavAgent.destination = agentPos + randomPos;
        }
    }

    public override void Exit()
    {
        base.Exit();

        SetWeight(-1);
    }
}