using UnityEngine;

/// <summary>
/// Let the agent deliver his resources to a target position
/// </summary>
public class DeliverResources : UtilityAction
{
    private GameObject building;
    private Vector3 deliverPos;
    private readonly string buildingTag;
    private readonly float reachingDistance = 5.0f;


    public DeliverResources(string buildingTag, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.buildingTag = buildingTag;
    }

    public override void Enter()
    {
        base.Enter();

        building = GameCache._Cache.GetData(buildingTag);

        // Get delivery position
        for (int i = 0; i < _agent._AgentController._PlayerOwner._PlayerBuildings.Count; i++)
        {
            if (building.CompareTag(_agent._AgentController._PlayerOwner._PlayerBuildings[i].tag))
            {
                deliverPos = _agent._AgentController._PlayerOwner._PlayerBuildings[i].transform.position;
            }
        }
    }

    public override void Execute()
    {
        base.Execute();

        // Walk towards delivery position
        _agent._AgentController._NavAgent.destination = deliverPos;

        if ((deliverPos - _agent.transform.position).sqrMagnitude < reachingDistance)
        {
            _agent._AgentController._Inventory.TransferItems(_agent._AgentController._PlayerOwner);
        }
    }
}