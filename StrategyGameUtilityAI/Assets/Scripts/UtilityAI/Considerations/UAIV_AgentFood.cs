/// <summary>
/// Get agent food count
/// </summary>
public class UAIV_AgentFood : UtilityValue
{
    public UAIV_AgentFood(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._AgentData.Food;
    }
}
