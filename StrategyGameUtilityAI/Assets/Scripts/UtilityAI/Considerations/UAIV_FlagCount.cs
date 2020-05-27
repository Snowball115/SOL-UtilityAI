public class UAIV_FlagCount : UtilityValue
{
    public UAIV_FlagCount(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._PlayerOwner._CapturedCPs.Count;
    }
}
