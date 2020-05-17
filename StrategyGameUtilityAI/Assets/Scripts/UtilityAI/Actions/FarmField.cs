using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmField : UtilityAction
{
    private GameObject farmPos;
    private float miningRange = 1.5f;


    public FarmField(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        // Agent should not run into the tree when chopping it
        _agent._AgentController._NavAgent.stoppingDistance = miningRange - 0.1f;

        // Check if a lumberyard is placed, if not build one
        if (!_agent.GetComponent<Farmer>().isFarmPlaced)
        {
            _agent.GetComponent<Farmer>().isFarmPlaced = true;
            GameObject go = MonoBehaviour.Instantiate(GameCache._Cache.GetData("Farm"), _agent.transform.position - Vector3.up, Quaternion.identity, _agent._AgentController._PlayerOwner._BuildingParentHolder);
            go.name = go.name.Replace("(Clone)", "");
            go.GetComponent<Building>()._PlayerOwner = _agent._AgentController._PlayerOwner;
            _agent._AgentController._PlayerOwner._PlayerBuildings.Add(go);
        }

        farmPos = _agent._AgentController._PlayerOwner.GetBuilding_ByTag(GameCache._Cache.GetData("Farm").tag);
    }

    public override void Execute()
    {
        base.Execute();

        // Move to farm and start farming (GIVES FOR EXACTLY ONE FRAME A NULL REFERENCE ERROR - WHY???)
        if (farmPos == null) return;
        _agent._AgentController._NavAgent.destination = farmPos.transform.position;

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
