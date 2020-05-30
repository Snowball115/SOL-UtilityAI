using UnityEngine;

/// <summary>
/// Flee from enemy action
/// </summary>
public class Flee : UtilityAction
{
    private GameObject targetToFleeFrom;
    private Vector3 fleePos;


    public Flee(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Execute()
    {
        base.Execute();

        targetToFleeFrom = _agent._AgentController._Senses.GetClosestEnemy();

        // Get distance to enemy
        float distance = (targetToFleeFrom.transform.position - _agent.transform.position).sqrMagnitude;

        // Calculate flee position
        fleePos = new Vector3((targetToFleeFrom.transform.position.x + distance) * -1, 0, (targetToFleeFrom.transform.position.z + distance) * -1);

        _agent._AgentController._NavAgent.destination = fleePos;
    }
}
