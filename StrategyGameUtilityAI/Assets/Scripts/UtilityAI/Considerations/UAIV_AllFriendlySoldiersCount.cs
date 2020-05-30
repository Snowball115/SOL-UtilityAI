/// <summary>
/// All friendly soldiers that are active count
/// </summary>
public class UAIV_AllFriendlySoldiersCount : UtilityValue
{
    public UAIV_AllFriendlySoldiersCount(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._PlayerOwner._CurrentSoldiersCount;
    }
}
