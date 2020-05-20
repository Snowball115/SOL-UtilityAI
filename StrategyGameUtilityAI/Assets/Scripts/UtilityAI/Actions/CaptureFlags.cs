using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Capture flags on the map
/// </summary>
public class CaptureFlags : UtilityAction
{
    // Positions where the agent should patrol
    public List<GameObject> waypoints;
    private int waypointIndex = 0;

    private GameObject nearestFlag;


    public CaptureFlags(List<GameObject> waypoints, UtilityAgent agent, float initialScore) : base(agent, initialScore)
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

        // Get nearest flag
        if (_agent._AgentController._Senses.ContainsObject(GameCache._Cache.GetData("CapturePoint")))
        {
            nearestFlag = _agent._AgentController._Senses.GetClosestObject(GameCache._Cache.GetData("CapturePoint"));

            // Capture the flag if its not captured
            if (nearestFlag.GetComponent<CapturePoint>()._TeamOwner != _agent._AgentController._PlayerOwner)
            {
                _agent._AgentController._NavAgent.destination = nearestFlag.transform.position;
                return;
            }
        }

        // Move to next flag
        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < 1.0f)
        {
            _agent._AgentController._NavAgent.destination = waypoints[waypointIndex].transform.position;

            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }
}
