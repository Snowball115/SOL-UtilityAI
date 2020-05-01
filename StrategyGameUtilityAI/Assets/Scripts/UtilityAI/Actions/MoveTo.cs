using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : UtilityAction
{
    // Position the agent should move at
    public GameObject goalPos;

    // NavMeshAgent component
    private NavMeshAgent navAgent;


    public MoveTo(GameObject goalPos, MonoBehaviour mb, float initialScore) : base(mb, initialScore)
    {
        this.goalPos = goalPos;
    }

    public override void Enter()
    {
        base.Execute();

        navAgent = agentMB.GetComponent<NavMeshAgent>();
    }

    public override void Execute()
    {
        base.Execute();

        navAgent.destination = goalPos.transform.position;
    }
}
