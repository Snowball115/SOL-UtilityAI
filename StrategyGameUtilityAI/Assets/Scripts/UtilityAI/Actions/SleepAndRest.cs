using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAndRest : UtilityAction
{
    private GameObject placeToRest;
    private string buildingTag;
    private float timer;
    private readonly float reachingDistance = 5.0f;


    public SleepAndRest(string buildingTag, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.buildingTag = buildingTag;
    }

    public override void Enter()
    {
        base.Enter();

        placeToRest = _agent._AgentController._PlayerOwner.GetBuilding_ByTag(buildingTag);
    }

    public override void Execute()
    {
        base.Enter();

        _agent._AgentController._NavAgent.destination = placeToRest.transform.position;

        if ((placeToRest.transform.position - _agent.transform.position).sqrMagnitude < reachingDistance)
        {
            timer += Time.deltaTime;

            while (timer > 0.3f)
            {
                timer = 0.0f;
                _agent._AgentController.Rest();
            }
        }
    }
}
