using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : UtilityAction
{
    private GameObject closestTree;
    private float miningRange;


    public ChopTree(float miningRange, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.miningRange = miningRange;
    }

    public override void Execute()
    {
        base.Execute();

        // First check if a lumberyard is placed, if not build one
        if (!_agent.GetComponent<Lumberjack>().isLumberyardPlaced)
        {
            _agent.GetComponent<Lumberjack>().isLumberyardPlaced = true;
            GameObject go = MonoBehaviour.Instantiate(GameCache._Cache.GetData("Lumberyard"), _agent.transform.position - Vector3.up, Quaternion.identity, _agent._AgentController._PlayerOwner._BuildingParentHolder);
            go.name = go.name.Replace("(Clone)", "");
            _agent._AgentController._PlayerOwner._PlayerBuildings.Add(go);
        }

        // Move to closest tree and chop it
        closestTree = _agent._AgentController._Senses.GetClosestObject(GameCache._Cache.GetData("Tree"));

        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < miningRange)
        {
            _agent._AgentController._NavAgent.destination = closestTree.transform.position;

            _agent._AgentController._Inventory.Add(closestTree.GetComponent<ResourceBase>().GetMined());
        }
    }
}