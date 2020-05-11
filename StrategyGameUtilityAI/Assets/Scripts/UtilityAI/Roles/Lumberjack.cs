using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        MoveTo moveAction_HealthTest = new MoveTo(GameObject.Find("PositionC"), this, 0.1f);
        moveAction_HealthTest.AddScorer(Scorer_AgentHealth);

        MoveTo moveAction_TreeTest = new MoveTo(GameObject.Find("PositionB"), this, 0.1f);
        moveAction_TreeTest.AddScorer(Scorer_TreeCount);

        Patrol patrolAction = new Patrol(Waypoints, this, 0.5f);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(patrolAction);
        _AgentActions.Add(moveAction_TreeTest);
        _AgentActions.Add(moveAction_HealthTest);
    }

    public void PlaceLumberyard(Vector3 targetPos)
    {
        _isLumberyardPlaced = true;
        GameObject go = Instantiate(GameCache._GameCache.GetData("Lumberyard"));
    }
}