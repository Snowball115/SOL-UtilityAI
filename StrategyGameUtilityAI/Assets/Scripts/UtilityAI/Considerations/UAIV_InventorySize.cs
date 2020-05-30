/// <summary>
/// Get current Inventory size of agent
/// </summary>
public class UAIV_InventorySize : UtilityValue
{
    public UAIV_InventorySize(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        _CurrentValue = _agent._AgentController._Inventory.GetCurrentInventorySize();
    }
}
