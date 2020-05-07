using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : UtilityAgent
{
    public List<GameObject> Waypoints;

    public UtilityScorer testScorer;
    public UtilityScorer testScorer2;
    public UtilityScorer testScorer3;


    protected override void Start()
    {
        base.Start();

        //UAIV_TreeCount treeCount = ScriptableObject.CreateInstance<UAIV_TreeCount>();
        UAIV_TreeCount treeCount = new UAIV_TreeCount(this);
        treeCount._MaxValue = 5;

        MoveTo moveAction = new MoveTo(GameObject.Find("PositionB"), this, 0.1f);
        //moveAction.Scorers.Add(testScorer);
        //moveAction.Scorers.Add(testScorer2);
        testScorer3._ReferenceValue = treeCount;
        moveAction._Scorers.Add(testScorer3);

        Patrol patrolAction = new Patrol(Waypoints, this, 0.5f);

        _AgentActions.Add(patrolAction);
        _AgentActions.Add(moveAction);
    }
}