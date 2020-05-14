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
    public soAnimationCurve _TreeCountCurve;
    public soAnimationCurve _InventorySizeCurve;

    public GenericCache<string, object> _Blackboard { get; private set; }


    protected override void Start()
    {
        base.Start();

        _Blackboard = new GenericCache<string, object>();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);
        UAIV_TreeCount treeCount = new UAIV_TreeCount(this, 4);
        UAIV_InventorySize inventorySize = new UAIV_InventorySize(this, _AgentController._Inventory._MaxInventorySize);

        // ****** SCORERS ******
        UtilityScorer Scorer_AgentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer Scorer_TreeCount = new UtilityScorer(treeCount, _TreeCountCurve);
        UtilityScorer Scorer_InventorySize = new UtilityScorer(inventorySize, _InventorySizeCurve);

        // ****** ACTIONS ******
        MoveTo moveAction_HealthTest = new MoveTo(GameObject.Find("TestPos"), this, 0.0f);
        moveAction_HealthTest.AddScorer(Scorer_AgentHealth);

        RoamAround roamAction_SearchTrees = new RoamAround(this, 0.1f);
        //roamAction_SearchTrees.AddScorer(Scorer_TreeCount);

        ChopTree chopTreeAction = new ChopTree(0.5f, this, 0.0f);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchTrees);
        _AgentActions.Add(moveAction_HealthTest);
    }

    void Update()
    {
        GameObject go = _AgentController._Senses.GetClosestObject(GameCache._GameCache.GetData("Tree"));
    }
}