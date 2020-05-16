using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverResources : UtilityAction
{
    private Vector3 lumberyardPos;
    private string buildingTag;


    public DeliverResources(string buildingTag, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.buildingTag = buildingTag;
    }

    public override void Enter()
    {
        base.Enter();

        GameObject lumberyard = GameCache._Cache.GetData(buildingTag);

        for (int i = 0; i < _agent._AgentController._PlayerOwner._PlayerBuildings.Count; i++)
        {
            if (lumberyard.CompareTag(_agent._AgentController._PlayerOwner._PlayerBuildings[i].tag))
            {
                lumberyardPos = _agent._AgentController._PlayerOwner._PlayerBuildings[i].transform.position;
            }
        }
    }

    public override void Execute()
    {
        base.Execute();

        _agent._AgentController._NavAgent.destination = lumberyardPos;

        if (_agent._AgentController._NavAgent.remainingDistance < 0.5f)
        {
            
            //_agent._AgentController._Inventory.Add(closestTree.GetComponent<EntityController>().GetMined());
        }
    }
}
