using UnityEngine;

/// <summary>
/// Action for mining ores
/// </summary>
public class MineOre : UtilityAction
{
    private GameObject closestOre;
    private float miningRange = 2.5f;


    public MineOre(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        // Agent should not run into the ore when mining it
        _agent._AgentController._NavAgent.stoppingDistance = miningRange - 0.2f;

        // Check if a mine is placed, if not build one
        if (!_agent.GetComponent<Miner>().isMinePlaced)
        {
            _agent.GetComponent<Miner>().isMinePlaced = true;

            _agent._AgentController._PlayerOwner.ConstructBuilding(GameCache._Cache.GetData("Mine"), _agent.transform.position);
        }
    }

    public override void Execute()
    {
        base.Execute();

        // Move to closest ore and mine it
        closestOre = _agent._AgentController._Senses.GetClosestObject(GameCache._Cache.GetData("Ore"));

        _agent._AgentController._NavAgent.destination = closestOre.transform.position;

        // Mine ore if in mining range
        if (!_agent._AgentController._NavAgent.pathPending && _agent._AgentController._NavAgent.remainingDistance < miningRange)
        {
            _agent._AgentController._Inventory.Add(closestOre.GetComponent<EntityController>().GetMined());
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Stopping distance set to zero to avoid problems with other actions
        _agent._AgentController._NavAgent.stoppingDistance = 0.0f;
    }
}