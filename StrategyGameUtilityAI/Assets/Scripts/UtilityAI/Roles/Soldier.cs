﻿using System.Collections;
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

        SortAllCapturePoints();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_SoldierFriendlyCount friendlySoldierCount = new UAIV_SoldierFriendlyCount(this, 3);
        UAIV_SoldierEnemyCount enemySoldierCount = new UAIV_SoldierEnemyCount(this, 3);

        // ****** SCORERS ******
        UtilityScorer scorer_friendlyCount = new UtilityScorer(friendlySoldierCount, _FriendlyAgentsCurve);
        UtilityScorer scorer_enemyCount = new UtilityScorer(enemySoldierCount, _EnemyAgentsCurve);

        // ****** ACTIONS ******
        CaptureFlags captureFlagsAction = new CaptureFlags(capturePointsInScene, this, 0.5f);
        captureFlagsAction.AddScorer(scorer_friendlyCount);
        captureFlagsAction.AddScorer(scorer_enemyCount);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(captureFlagsAction);
    }

    private void SortAllCapturePoints()
    {
        capturePointsInScene = new List<GameObject>();
        capturePointsInScene = GameCache._CapturePointsList;
    }
}
