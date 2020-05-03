using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : UtilityAgent
{
    public List<GameObject> Waypoints;

    public UtilityScorer testScorer;

    protected override void Start()
    {
        base.Start();

        MoveTo moveAction = new MoveTo(GameObject.Find("PositionB"), this, 0.1f);
        moveAction.Scorers.Add(testScorer);

        AgentActions.Add(new Patrol(Waypoints, this, 0.5f));
        AgentActions.Add(moveAction);
    }
}