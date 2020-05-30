using UnityEngine;

/// <summary>
/// Get the distance to nearby enemy
/// </summary>
public class UAIV_DistanceToEnemy : UtilityValue
{
    private GameObject closestEnemy;


    public UAIV_DistanceToEnemy(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        // Check if the agent sees an enemy
        if (_agent._AgentController._Senses.ContainsEnemyInSight())
        {
            closestEnemy = _agent._AgentController._Senses.GetClosestEnemy();

            // Get distance to enemy
            _CurrentValue = (closestEnemy.transform.position - _agent.transform.position).magnitude;
        }

        else _CurrentValue = _MaxValue;
    }
}
