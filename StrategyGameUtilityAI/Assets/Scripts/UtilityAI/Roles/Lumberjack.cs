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
    public soAnimationCurve HealthCurve;
    public soAnimationCurve TreeCurve;

    // Gameplay data
    private bool _isLumberyardPlaced;
    private Vector3 _lumberyardPos;

    // Test stuff
    public List<GameObject> Waypoints;


    protected override void Start()
    {
        base.Start();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);
        UAIV_TreeCount treeCount = new UAIV_TreeCount(this, 4);

        // ****** SCORERS ******
        UtilityScorer Scorer_AgentHealth = new UtilityScorer(agentHealth, HealthCurve);
        UtilityScorer Scorer_TreeCount = new UtilityScorer(treeCount, TreeCurve);

        // ****** ACTIONS ******
        MoveTo moveAction_HealthTest = new MoveTo(GameObject.Find("PositionC"), this, 0.0f);
        moveAction_HealthTest.AddScorer(Scorer_AgentHealth);

        RoamAround roamAction_SearchTrees = new RoamAround(0.1f, this, 0.1f);
        //roamAction_SearchTrees.AddScorer(Scorer_TreeCount);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(roamAction_SearchTrees);
        _AgentActions.Add(moveAction_HealthTest);
    }

    public void PlaceLumberyard(Vector3 targetPos)
    {
        _isLumberyardPlaced = true;
        GameObject go = Instantiate(GameCache._GameCache.GetData("Lumberyard"));
        _lumberyardPos = go.transform.position;
    }
}