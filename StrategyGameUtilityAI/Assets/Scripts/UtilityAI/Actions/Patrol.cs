using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : UtilityAction
{
    // NavMeshAgent component
    private NavMeshAgent navAgent;

    // Position the agent should move at
    public List<GameObject> waypoints;
    private int waypointIndex = 0;


    public Patrol(List<GameObject> waypoints, MonoBehaviour mb, float initialScore) : base(mb, initialScore)
    {
        this.waypoints = waypoints;
    }

    public override void Enter()
    {
        base.Execute();

        navAgent = agentMB.GetComponent<NavMeshAgent>();

        navAgent.autoBraking = false;
    }

    public override void Execute()
    {
        base.Execute();

        if (waypoints.Count == 0) return;

        if (!navAgent.pathPending && navAgent.remainingDistance < 0.5f)
        {
            navAgent.destination = waypoints[waypointIndex].transform.position;

            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }
}
