using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        base.Execute();

        agent.AgentController.NavAgent.autoBraking = false;
    }

    public override void Execute()
    {
        base.Execute();

        if (waypoints.Count == 0) return;

        if (!agent.AgentController.NavAgent.pathPending && agent.AgentController.NavAgent.remainingDistance < 0.5f)
        {
            agent.AgentController.NavAgent.destination = waypoints[waypointIndex].transform.position;

            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
