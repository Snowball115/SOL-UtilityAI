using System.Collections.Generic;
using UnityEngine;

public class Soldier : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FriendlyAgentsCurve;
    public soAnimationCurve _EnemyAgentsCurve;
    public soAnimationCurve _AttackDesire;

    private List<GameObject> capturePointsInScene;


    protected override void Start()
    {
        base.Start();

        GetAllCapturePoints();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);
        UAIV_SoldierFriendlyCount friendlySoldierCount = new UAIV_SoldierFriendlyCount(this, 4);
        UAIV_SoldierEnemyCount enemySoldierCount = new UAIV_SoldierEnemyCount(this, 3);
        UAIV_DistanceToEnemy distanceToEnemy = new UAIV_DistanceToEnemy(this, _AgentController._Senses._ViewRange);

        // ****** SCORERS ******
        UtilityScorer scorer_agentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_friendlyCount = new UtilityScorer(friendlySoldierCount, _FriendlyAgentsCurve);
        UtilityScorer scorer_enemyCount = new UtilityScorer(enemySoldierCount, _EnemyAgentsCurve);
        UtilityScorer scorer_distanceToEnemy = new UtilityScorer(distanceToEnemy, _AttackDesire);

        // ****** ACTIONS ******
        //WaitForTroops waitForTroopsAction = new WaitForTroops(this, 0.0f);

        CaptureFlags captureFlagsAction = new CaptureFlags(capturePointsInScene, this, 0.5f);
        //captureFlagsAction.AddScorer(scorer_friendlyCount);

        AttackEnemy attackEnemyAction = new AttackEnemy(this, 0.0f);
        attackEnemyAction.AddScorer(scorer_distanceToEnemy);

        Flee fleeAction = new Flee(this, 0.0f);
        fleeAction.AddScorer(scorer_agentHealth);
        fleeAction.AddScorer(scorer_enemyCount);
        fleeAction.AddScorer(scorer_friendlyCount);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(captureFlagsAction);
        _AgentActions.Add(attackEnemyAction);
        _AgentActions.Add(fleeAction);
    }

    // Agent saves all CapturePoints on the map
    private void GetAllCapturePoints()
    {
        capturePointsInScene = new List<GameObject>();
        capturePointsInScene = GameCache._CapturePointsList;
    }
}
