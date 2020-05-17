﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Let the agent deliver its resources to a target position
/// </summary>
public class DeliverResources : UtilityAction
{
    private Vector3 deliverPos;
    private readonly string buildingTag;


    public DeliverResources(string buildingTag, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.buildingTag = buildingTag;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject buidling = GameCache._Cache.GetData(buildingTag);

        for (int i = 0; i < _agent._AgentController._PlayerOwner._PlayerBuildings.Count; i++)
        {
            if (buidling.CompareTag(_agent._AgentController._PlayerOwner._PlayerBuildings[i].tag))
            {
                deliverPos = _agent._AgentController._PlayerOwner._PlayerBuildings[i].transform.position;
            }
        }
    }

    public override void Execute()
    {
        base.Execute();

        _agent._AgentController._NavAgent.destination = deliverPos;

        if (_agent._AgentController._NavAgent.remainingDistance < 0.5f)
        {
            _agent._AgentController._Inventory.TransferItems(_agent._AgentController._PlayerOwner._playerInventory);
        }
    }
}