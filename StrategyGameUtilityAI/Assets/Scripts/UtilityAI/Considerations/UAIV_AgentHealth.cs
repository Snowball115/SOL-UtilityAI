/// <summary>
/// Get agents current health points
/// </summary>
public class UAIV_AgentHealth : UtilityValue
{
    public UAIV_AgentHealth(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._AgentData.Health;
    }
}
