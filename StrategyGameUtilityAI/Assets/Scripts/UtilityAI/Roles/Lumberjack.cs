using UnityEngine;

/// <summary>
/// Lumberjack agent role
/// </summary>
public class Lumberjack : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FoodCurve;
    public soAnimationCurve _EnergyCurve;
    public soAnimationCurve _LumberyardPlacedCurve;
    public soAnimationCurve _TreeCountCurve;
    public soAnimationCurve _InventorySizeCurve;
    public soAnimationCurve _EnemySoldierThreatCurve;

    // Is a lumberyard placed by the agent?
    public bool isLumberyardPlaced { get; set; }


    protected override void Start()
    {
        base.Start();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, _AgentController._AgentStats.HealthPoints);
        UAIV_AgentFood agentFood = new UAIV_AgentFood(this, _AgentController._AgentStats.FoodPoints);
        UAIV_AgentEnergy agentEnergy = new UAIV_AgentEnergy(this, _AgentController._AgentStats.EnergyPoints);
        UAIV_LumberyardPlaced lumberyardPlaced = new UAIV_LumberyardPlaced(this, 1);
        UAIV_ResourceCount treeCount = new UAIV_ResourceCount(GameCache._Cache.GetData("Tree").tag, this, 4);
        UAIV_InventorySize inventorySize = new UAIV_InventorySize(this, _AgentController._Inventory._MaxInventorySize);
        UAIV_SoldierEnemyCount enemySoldierCount = new UAIV_SoldierEnemyCount(this, 2.0f);

        // ****** SCORERS ******
        UtilityScorer scorer_AgentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_AgentFood = new UtilityScorer(agentFood, _FoodCurve);
        UtilityScorer scorer_AgentEnergy = new UtilityScorer(agentEnergy, _EnergyCurve);
        UtilityScorer scorer_LumberyardBoolCheck = new UtilityScorer(lumberyardPlaced, _LumberyardPlacedCurve);
        UtilityScorer scorer_TreeCount = new UtilityScorer(treeCount, _TreeCountCurve);
        UtilityScorer scorer_InventorySize = new UtilityScorer(inventorySize, _InventorySizeCurve);
        UtilityScorer scorer_enemySoldierThreatLevel = new UtilityScorer(enemySoldierCount, _EnemySoldierThreatCurve);

        // ****** ACTIONS ******
        RoamAround roamAction_SearchTrees = new RoamAround(this, 1.0f);
        roamAction_SearchTrees.AddScorer(scorer_TreeCount);
        roamAction_SearchTrees.AddScorer(scorer_LumberyardBoolCheck);

        ChopTree chopTreeAction = new ChopTree(this, 0.5f);

        DeliverResources deliverResourceAction = new DeliverResources(GameCache._Cache.GetData("Lumberyard").tag, this, 0.0f);
        deliverResourceAction.AddScorer(scorer_InventorySize);

        EatFood eatFoodAction = new EatFood(this, 0.0f);
        eatFoodAction.AddScorer(scorer_AgentFood);
        eatFoodAction.SetWeight(2);

        SleepAndRest sleepRestAction = new SleepAndRest("Lumberyard", this, 0.0f);
        sleepRestAction.AddScorer(scorer_AgentEnergy);

        Hide hideAction = new Hide("Headquarters", this, 0.0f);
        hideAction.AddScorer(scorer_enemySoldierThreatLevel);
        hideAction.SetWeight(3);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchTrees);
        _AgentActions.Add(chopTreeAction);
        _AgentActions.Add(deliverResourceAction);
        _AgentActions.Add(eatFoodAction);
        _AgentActions.Add(sleepRestAction);
        _AgentActions.Add(hideAction);
    }

    protected override void Update()
    {
        base.Update();

        CheckForLumberyard();
    }

    // Check if an lumberyard is already placed, so it don't need to be placed again
    private void CheckForLumberyard()
    {
        if (!isLumberyardPlaced)
        {
            for (int i = 0; i < _AgentController._PlayerOwner._PlayerBuildings.Count; i++)
            {
                if (_AgentController._PlayerOwner._PlayerBuildings[i].CompareTag(GameCache._Cache.GetData("Lumberyard").tag))
                {
                    isLumberyardPlaced = true;
                }
            }
        }
    }

}