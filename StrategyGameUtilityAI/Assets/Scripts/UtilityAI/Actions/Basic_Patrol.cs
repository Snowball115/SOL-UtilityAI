using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Patrol between waypoints
/// </summary>
public class Patrol : UtilityAction
{
    // Positions where the agent should patrol
    public List<GameObject> waypoints;
    private int waypointIndex = 0;


    public Patrol(List<GameObject> waypoints, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.waypoints = waypoints;
    }

    public override void Enter()
    {
        base.Enter();

        _agent._AgentController._NavAgent.autoBraking = false;
    }

    public override void Execute()
    {
        base.Execute();

        if (waypoints.Count == 0) return;

        // Walk to next waypoint if old one is reached
        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < 0.5f)
        {
            _agent._AgentController._NavAgent.destination = waypoints[waypointIndex].transform.position;

            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }
}
