using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New MoveTo", menuName = "Utility Actions/Move To")]
public class MoveTo : UtilityAction
{
    // Position the agent should move at
    public GameObject goalPos;

    // NavMeshAgent component
    private NavMeshAgent navAgent;


    public MoveTo(GameObject goalPos, float score)
    {
        this.goalPos = goalPos;
        UtilityScore = score;
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
