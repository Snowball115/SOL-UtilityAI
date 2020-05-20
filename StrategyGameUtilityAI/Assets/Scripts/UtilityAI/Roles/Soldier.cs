using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;

    private List<GameObject> capturePointsInScene;


    protected override void Start()
    {
        base.Start();

        SortAllCapturePoints();

        // Utility AI setup

        // ****** VALUES ******


        // ****** SCORERS ******


        // ****** ACTIONS ******
        Patrol patrolCPsAction = new Patrol(capturePointsInScene, this, 0.5f);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(patrolCPsAction);
    }

    private void SortAllCapturePoints()
    {
        capturePointsInScene = new List<GameObject>();
        capturePointsInScene = GameCache._CapturePointsList;
    }
}
