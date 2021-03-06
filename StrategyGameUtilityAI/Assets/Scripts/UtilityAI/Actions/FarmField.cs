﻿using UnityEngine;

/// <summary>
/// Farming fields action
/// </summary>
public class FarmField : UtilityAction
{
    private GameObject farmPos;
    private float miningRange = 2.5f;


    public FarmField(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        // Agent should not run into the tree when chopping it
        _agent._AgentController._NavAgent.stoppingDistance = miningRange - 0.2f;

        // Check if a farm is placed, if not build one
        if (!_agent.GetComponent<Farmer>().isFarmPlaced)
        {
            _agent.GetComponent<Farmer>().isFarmPlaced = true;

            _agent._AgentController._PlayerOwner.ConstructBuilding(GameCache._Cache.GetData("Farm"), _agent.transform.position);
        }

        farmPos = _agent._AgentController._PlayerOwner.GetBuilding_ByTag(GameCache._Cache.GetData("Farm").tag);
    }

    public override void Execute()
    {
        base.Execute();
        
        if (farmPos == null) return;

        _agent._AgentController._NavAgent.destination = farmPos.transform.position;

        // Move to farm and start farming if close enough
        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < miningRange)
        {
            _agent._AgentController._Inventory.Add(farmPos.GetComponent<EntityController>().GetMined());
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Stopping distance set to zero to avoid problems with other actions
        _agent._AgentController._NavAgent.stoppingDistance = 0.0f;
    }
}
