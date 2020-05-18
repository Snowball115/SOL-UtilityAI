using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Action for chopping trees
/// </summary>
public class ChopTree : UtilityAction
{
    private GameObject closestTree;
    private float miningRange = 1.5f;


    public ChopTree(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        // Agent should not run into the tree when chopping it
        _agent._AgentController._NavAgent.stoppingDistance = miningRange - 0.1f;

        // Check if a lumberyard is placed, if not build one
        if (!_agent.GetComponent<Lumberjack>().isLumberyardPlaced)
        {
            _agent.GetComponent<Lumberjack>().isLumberyardPlaced = true;
            GameObject go = MonoBehaviour.Instantiate(GameCache._Cache.GetData("Lumberyard"), _agent.transform.position - Vector3.up, Quaternion.identity, _agent._AgentController._PlayerOwner._BuildingParentHolder);
            go.name = go.name.Replace("(Clone)", "");
            go.GetComponent<Building>()._PlayerOwner = _agent._AgentController._PlayerOwner;
            _agent._AgentController._PlayerOwner._PlayerBuildings.Add(go);
        }
    }

    public override void Execute()
    {
        base.Execute();

        // Move to closest tree and chop it
        closestTree = _agent._AgentController._Senses.GetClosestObject(GameCache._Cache.GetData("Tree"));

        _agent._AgentController._NavAgent.destination = closestTree.transform.position;

        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < miningRange)
        {
            _agent._AgentController._Inventory.Add(closestTree.GetComponent<EntityController>().GetMined());
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Stopping distance set to zero to avoid problems with other actions
        _agent._AgentController._NavAgent.stoppingDistance = 0.0f;
    }
}