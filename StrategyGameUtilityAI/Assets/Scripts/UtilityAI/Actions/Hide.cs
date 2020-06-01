using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : UtilityAction
{
    private GameObject hideObject;
    private Vector3 posToHide;
    private string placeString;
    private float distanceToHide = 10.0f;


    public Hide(string placeString, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.placeString = placeString;
    }

    public override void Enter()
    {
        base.Enter();

        hideObject = _agent._AgentController._PlayerOwner.GetBuilding_ByTag(placeString);
        posToHide = hideObject.transform.position;

        _agent._AgentController._NavAgent.autoBraking = true;
    }

    public override void Execute()
    {
        base.Execute();

        _agent._AgentController._NavAgent.destination = posToHide;

        // Hide agent if close enough
        if ((posToHide - _agent.transform.position).sqrMagnitude < distanceToHide)
        {
            _agent.GetComponent<MeshRenderer>().enabled = false;

            // Hide agent from other agents
            _agent.gameObject.layer = 0;
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Show agent again
        _agent.GetComponent<MeshRenderer>().enabled = true;

        // Change layer back to visible
        _agent.gameObject.layer = 12;

        _agent._AgentController._NavAgent.autoBraking = false;
    }
}
