using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FriendlyAgentsCurve;
    public soAnimationCurve _EnemyAgentsCurve;

    private List<GameObject> capturePointsInScene;


    protected override void Start()
    {
        base.Start();

        GetAllCapturePoints();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);
        UAIV_SoldierFriendlyCount friendlySoldierCount = new UAIV_SoldierFriendlyCount(this, 3);
        UAIV_SoldierEnemyCount enemySoldierCount = new UAIV_SoldierEnemyCount(this, 3);

        // ****** SCORERS ******
        UtilityScorer scorer_agentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_friendlyCount = new UtilityScorer(friendlySoldierCount, _FriendlyAgentsCurve);
        UtilityScorer scorer_enemyCount = new UtilityScorer(enemySoldierCount, _EnemyAgentsCurve);

        // ****** ACTIONS ******
        //WaitForTroops waitForTroopsAction = new WaitForTroops(this, 0.0f);

        CaptureFlags captureFlagsAction = new CaptureFlags(capturePointsInScene, this, 0.5f);
        captureFlagsAction.AddScorer(scorer_friendlyCount);
        captureFlagsAction.AddScorer(scorer_enemyCount);

        AttackEnemy attackEnemyAction = new AttackEnemy(this, 0.0f);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(captureFlagsAction);
    }

    private void GetAllCapturePoints()
    {
        capturePointsInScene = new List<GameObject>();
        capturePointsInScene = GameCache._CapturePointsList;
    }
}
