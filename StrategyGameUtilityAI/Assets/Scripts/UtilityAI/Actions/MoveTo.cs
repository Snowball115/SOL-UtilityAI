using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : UtilityAction
{
    // Position the agent should move at
    public GameObject goalPos;


    public MoveTo(GameObject goalPos, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.goalPos = goalPos;
    }

    public override void Enter()
    {
        base.Execute();
    }

    public override void Execute()
    {
        base.Execute();

        agent.AgentController.NavAgent.destination = goalPos.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
