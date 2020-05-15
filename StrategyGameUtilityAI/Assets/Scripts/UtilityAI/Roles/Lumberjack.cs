using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lumberjack agent role
/// </summary>
public class Lumberjack : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _LumberyardPlacedCurve;
    public soAnimationCurve _TreeCountCurve;
    public soAnimationCurve _InventorySizeCurve;

    // Blackboard (Cache) for agent
    //public GenericCache<string, object> _Blackboard { get; private set; }

    // Is a lumberyard placed by the agent?
    public bool isLumberyardPlaced { get; set; }


    protected override void Start()
    {
        base.Start();

        //_Blackboard = new GenericCache<string, object>();
        //_Blackboard.Add("isLumberyardPlaced", isLumberyardPlaced);

        // -- Utility AI setup --

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);
        UAIV_LumberyardPlaced lumberyardPlaced = new UAIV_LumberyardPlaced(this, 1);
        UAIV_TreeCount treeCount = new UAIV_TreeCount(this, 4);
        UAIV_InventorySize inventorySize = new UAIV_InventorySize(this, _AgentController._Inventory._MaxInventorySize);

        // ****** SCORERS ******
        UtilityScorer scorer_AgentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_LumberyardBoolCheck = new UtilityScorer(lumberyardPlaced, _LumberyardPlacedCurve);
        UtilityScorer scorer_TreeCount = new UtilityScorer(treeCount, _TreeCountCurve);
        UtilityScorer scorer_InventorySize = new UtilityScorer(inventorySize, _InventorySizeCurve);

        // ****** ACTIONS ******
        RoamAround roamAction_SearchTrees = new RoamAround(this, 1.0f);
        roamAction_SearchTrees.AddScorer(scorer_TreeCount);
        roamAction_SearchTrees.AddScorer(scorer_LumberyardBoolCheck);

        ChopTree chopTreeAction = new ChopTree(0.5f, this, 0.5f);

        DeliverResources deliverResourceAction = new DeliverResources("Lumberyard", this, 0.0f);

        MoveTo moveAction_HealthTest = new MoveTo(GameObject.Find("TestPos"), this, 0.0f);
        moveAction_HealthTest.AddScorer(scorer_AgentHealth);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchTrees);
        _AgentActions.Add(chopTreeAction);
        _AgentActions.Add(moveAction_HealthTest);
    }

    void Update()
    {
        CheckForLumberyard();
    }

    // Check if an lumberyard is already placed, so it don't need to placed again
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