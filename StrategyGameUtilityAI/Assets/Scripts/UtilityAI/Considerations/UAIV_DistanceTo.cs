using UnityEngine;

/// <summary>
/// Calculate distance between the agent and another object
/// </summary>
public class UAIV_DistanceTo : UtilityValue
{
    private GameObject target;


    public UAIV_DistanceTo(GameObject target, UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue)
    {
        this.target = target;
    }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        if (target == null) return;

        _CurrentValue = (target.transform.position - _agent.transform.position).magnitude;
    }
}
