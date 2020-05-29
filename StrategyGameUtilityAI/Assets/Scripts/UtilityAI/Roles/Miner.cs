using UnityEngine;

/// <summary>
/// Miner agent role
/// </summary>
public class Miner : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FoodCurve;
    public soAnimationCurve _EnergyCurve;
    public soAnimationCurve _MinePlacedCurve;
    public soAnimationCurve _OreCountCurve;
    public soAnimationCurve _InventorySizeCurve;

    // Is a mine placed by the agent?
    public bool isMinePlaced { get; set; }


    protected override void Start()
    {
        base.Start();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, _AgentController._AgentStats.HealthPoints);
        UAIV_AgentFood agentFood = new UAIV_AgentFood(this, _AgentController._AgentStats.FoodPoints);
        UAIV_AgentEnergy agentEnergy = new UAIV_AgentEnergy(this, _AgentController._AgentStats.EnergyPoints);
        UAIV_MinePlaced minePlaced = new UAIV_MinePlaced(this, 1);
        UAIV_ResourceCount oreCount = new UAIV_ResourceCount(GameCache._Cache.GetData("Ore").tag, this, 1);
        UAIV_InventorySize inventorySize = new UAIV_InventorySize(this, _AgentController._Inventory._MaxInventorySize);

        // ****** SCORERS ******
        UtilityScorer scorer_AgentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_AgentFood = new UtilityScorer(agentFood, _FoodCurve);
        UtilityScorer scorer_AgentEnergy = new UtilityScorer(agentEnergy, _EnergyCurve);
        UtilityScorer scorer_OreBoolCheck = new UtilityScorer(minePlaced, _MinePlacedCurve);
        UtilityScorer scorer_OreCount = new UtilityScorer(oreCount, _OreCountCurve);
        UtilityScorer scorer_InventorySize = new UtilityScorer(inventorySize, _InventorySizeCurve);

        // ****** ACTIONS ******
        RoamAround roamAction_SearchOres = new RoamAround(this, 1.0f);
        roamAction_SearchOres.AddScorer(scorer_OreCount);
        roamAction_SearchOres.AddScorer(scorer_OreBoolCheck);

        MineOre mineOreAction = new MineOre(this, 0.5f);

        DeliverResources deliverResourceAction = new DeliverResources(GameCache._Cache.GetData("Mine").tag, this, 0.0f);
        deliverResourceAction.AddScorer(scorer_InventorySize);

        EatFood eatFoodAction = new EatFood(this, 0.0f);
        eatFoodAction.AddScorer(scorer_AgentFood);
        eatFoodAction.SetWeight(2);

        SleepAndRest sleepRestAction = new SleepAndRest("Mine", this, 0.0f);
        sleepRestAction.AddScorer(scorer_AgentEnergy);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchOres);
        _AgentActions.Add(mineOreAction);
        _AgentActions.Add(deliverResourceAction);
        _AgentActions.Add(eatFoodAction);
        _AgentActions.Add(sleepRestAction);
    }

    protected override void Update()
    {
        base.Update();

        CheckForMine();
    }

    // Check if an mine is already placed, so it don't need to be placed again
    private void CheckForMine()
    {
        if (!isMinePlaced)
        {
            for (int i = 0; i < _AgentController._PlayerOwner._PlayerBuildings.Count; i++)
            {
                if (_AgentController._PlayerOwner._PlayerBuildings[i].CompareTag(GameCache._Cache.GetData("Mine").tag))
                {
                    isMinePlaced = true;
                }
            }
        }
    }
}
