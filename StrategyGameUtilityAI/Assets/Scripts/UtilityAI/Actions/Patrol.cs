﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : UtilityAction
{
    // Positions where the agent should patrol
    public List<GameObject> waypoints;
    private int waypointIndex = 0;


    public Patrol(List<GameObject> waypoints, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.waypoints = waypoints;
    }

    public override void Execute()
    {
        base.Execute();

        _agent._AgentController._NavAgent.autoBraking = false;

        if (waypoints.Count == 0) return;

        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < 0.5f)
        {
            _agent._AgentController._NavAgent.destination = waypoints[waypointIndex].transform.position;

            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }
}
