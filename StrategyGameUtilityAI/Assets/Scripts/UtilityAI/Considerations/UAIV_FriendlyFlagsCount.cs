/// <summary>
/// All friendly flags the player owns
/// </summary>
public class UAIV_FriendlyFlagsCount : UtilityValue
{
    public UAIV_FriendlyFlagsCount(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._PlayerOwner._CapturedCPs.Count;
    }
}
