using UnityEngine;

/// <summary>
/// Farmer agent role
/// </summary>
public class Farmer : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FoodCurve;
    public soAnimationCurve _EnergyCurve;
    public soAnimationCurve _FarmPlacedCurve;
    public soAnimationCurve _DistanceToHQCurve;
    public soAnimationCurve _InventorySizeCurve;
    public soAnimationCurve _EnemySoldierThreatCurve;

    // Is a farm placed by the agent?
    public bool isFarmPlaced { get; set; }


    protected override void Start()
    {
        base.Start();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, _AgentController._AgentStats.HealthPoints);
        UAIV_AgentFood agentFood = new UAIV_AgentFood(this, _AgentController._AgentStats.FoodPoints);
        UAIV_AgentEnergy agentEnergy = new UAIV_AgentEnergy(this, _AgentController._AgentStats.EnergyPoints);
        UAIV_FarmPlaced farmPlaced = new UAIV_FarmPlaced(this, 1);
        UAIV_DistanceTo distanceToHQ = new UAIV_DistanceTo(_AgentController._PlayerOwner.GetBuilding_ByTag(GameCache._Cache.GetData("Headquarters").tag), this, 20);
        UAIV_InventorySize inventorySize = new UAIV_InventorySize(this, _AgentController._Inventory._MaxInventorySize);
        UAIV_SoldierEnemyCount enemySoldierCount = new UAIV_SoldierEnemyCount(this, 3.0f);

        // ****** SCORERS ******
        UtilityScorer scorer_AgentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_AgentFood = new UtilityScorer(agentFood, _FoodCurve);
        UtilityScorer scorer_AgentEnergy = new UtilityScorer(agentEnergy, _EnergyCurve);
        UtilityScorer scorer_FarmBoolCheck = new UtilityScorer(farmPlaced, _FarmPlacedCurve);
        UtilityScorer scorer_DistanceToHQ = new UtilityScorer(distanceToHQ, _DistanceToHQCurve);
        UtilityScorer scorer_InventorySize = new UtilityScorer(inventorySize, _InventorySizeCurve);
        UtilityScorer scorer_enemySoldierThreatLevel = new UtilityScorer(enemySoldierCount, _EnemySoldierThreatCurve);

        // ****** ACTIONS ******
        RoamAround roamAction_SearchFarmSpot = new RoamAround(this, 0.0f);
        roamAction_SearchFarmSpot.AddScorer(scorer_DistanceToHQ);
        roamAction_SearchFarmSpot.AddScorer(scorer_FarmBoolCheck);

        FarmField farmFieldAction = new FarmField(this, 0.5f);

        DeliverResources deliverResourceAction = new DeliverResources(GameCache._Cache.GetData("Headquarters").tag, this, 0.0f);
        deliverResourceAction.AddScorer(scorer_InventorySize);

        EatFood eatFoodAction = new EatFood(this, 0.0f);
        eatFoodAction.AddScorer(scorer_AgentFood);
        eatFoodAction.SetWeight(2);

        SleepAndRest sleepRestAction = new SleepAndRest("Field", this, 0.0f);
        sleepRestAction.AddScorer(scorer_AgentEnergy);

        Hide hideAction = new Hide("Headquarters", this, 0.0f);
        hideAction.AddScorer(scorer_enemySoldierThreatLevel);
        hideAction.SetWeight(3);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchFarmSpot);
        _AgentActions.Add(farmFieldAction);
        _AgentActions.Add(deliverResourceAction);
        _AgentActions.Add(eatFoodAction);
        _AgentActions.Add(sleepRestAction);
        _AgentActions.Add(hideAction);
    }

    protected override void Update()
    {
        base.Update();

        CheckForFarm();
    }

    // Check if a farm is already placed, so it don't need to be placed again
    private void CheckForFarm()
    {
        if (!isFarmPlaced)
        {
            for (int i = 0; i < _AgentController._PlayerOwner._PlayerBuildings.Count; i++)
            {
                if (_AgentController._PlayerOwner._PlayerBuildings[i].CompareTag(GameCache._Cache.GetData("Farm").tag))
                {
                    isFarmPlaced = true;
                }
            }
        }
    }
}