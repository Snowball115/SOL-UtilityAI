using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : UtilityAgent
{
    public List<GameObject> Waypoints;

    public UtilityScorer Scorer_TreeCount;
    public UtilityScorer Scorer_AgentHealth;


    protected override void Start()
    {
        base.Start();

        UAIV_TreeCount treeCount = new UAIV_TreeCount(this, 4);
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, 100);

        MoveTo moveAction_TreeTest = new MoveTo(GameObject.Find("PositionB"), this, 0.1f);
        Scorer_TreeCount._ReferenceValue = treeCount;
        moveAction_TreeTest._Scorers.Add(Scorer_TreeCount);

        MoveTo moveAction_HealthTest = new MoveTo(GameObject.Find("PositionC"), this, 0.1f);
        Scorer_AgentHealth._ReferenceValue = agentHealth;
        moveAction_HealthTest._Scorers.Add(Scorer_AgentHealth);

        Patrol patrolAction = new Patrol(Waypoints, this, 0.5f);

        _AgentActions.Add(patrolAction);
        _AgentActions.Add(moveAction_TreeTest);
        _AgentActions.Add(moveAction_HealthTest);
    }
}