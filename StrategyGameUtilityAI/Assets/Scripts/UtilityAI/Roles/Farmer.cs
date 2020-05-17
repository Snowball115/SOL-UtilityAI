using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FarmPlacedCurve;
    public soAnimationCurve _DistanceToHQCurve;
    public soAnimationCurve _InventorySizeCurve;

    // Is a farm placed by the agent?
    public bool isFarmPlaced { get; set; }


    protected override void Start()
    {
        base.Start();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);
        UAIV_AgentFood agentFood = new UAIV_AgentFood(this, 100);
        UAIV_FarmPlaced farmPlaced = new UAIV_FarmPlaced(this, 1);
        UAIV_DistanceTo distanceToHQ = new UAIV_DistanceTo(_AgentController._PlayerOwner.GetBuilding_ByTag(GameCache._Cache.GetData("Headquarters").tag), this, 22);
        UAIV_InventorySize inventorySize = new UAIV_InventorySize(this, _AgentController._Inventory._MaxInventorySize);

        // ****** SCORERS ******
        UtilityScorer scorer_AgentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_FarmBoolCheck = new UtilityScorer(farmPlaced, _FarmPlacedCurve);
        UtilityScorer scorer_DistanceToHQ = new UtilityScorer(distanceToHQ, _DistanceToHQCurve);
        UtilityScorer scorer_InventorySize = new UtilityScorer(inventorySize, _InventorySizeCurve);

        // ****** ACTIONS ******
        RoamAround roamAction_SearchFarmSpot = new RoamAround(this, 0.0f);
        roamAction_SearchFarmSpot.AddScorer(scorer_DistanceToHQ);
        roamAction_SearchFarmSpot.AddScorer(scorer_FarmBoolCheck);

        FarmField farmFieldAction = new FarmField(this, 0.5f);

        DeliverResources deliverResourceAction = new DeliverResources(GameCache._Cache.GetData("Headquarters").tag, this, 0.0f);
        deliverResourceAction.AddScorer(scorer_InventorySize);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchFarmSpot);
        _AgentActions.Add(farmFieldAction);
        _AgentActions.Add(deliverResourceAction);
    }

    void Update()
    {
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