using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Soldier agent role
/// </summary>
public class Soldier : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;
    public soAnimationCurve _FriendlyAgentsCurve;
    public soAnimationCurve _EnemyAgentsCurve;
    public soAnimationCurve _AttackDesireCurve;
    public soAnimationCurve _FleeDesireCurve;
    public soAnimationCurve _FriendlyFlagDistanceCurve;
    public soAnimationCurve _FriendlyFlagsForHQAttackCurve;
    public soAnimationCurve _AllFriendlyAgentsCountCurve;

    private List<GameObject> capturePointsInScene;


    protected override void Start()
    {
        base.Start();

        GetAllCapturePoints();

        // Utility AI setup

        // ****** VALUES ******
        UAIV_AgentHealth agentHealth = new UAIV_AgentHealth(this, _AgentController._AgentStats.HealthPoints);
        UAIV_SoldierFriendlyCount friendlySoldierCount = new UAIV_SoldierFriendlyCount(this, 4);
        UAIV_SoldierEnemyCount enemySoldierCount = new UAIV_SoldierEnemyCount(this, 3);
        UAIV_DistanceToEnemy distanceToEnemy = new UAIV_DistanceToEnemy(this, _AgentController._Senses._ViewRange);
        UAIV_DistanceToFriendlyFlag distanceToFriendlyFlag = new UAIV_DistanceToFriendlyFlag(this, _AgentController._Senses._ViewRange);
        UAIV_FriendlyFlagsCount friendlyFlagsCount = new UAIV_FriendlyFlagsCount(this, 5);
        UAIV_AllFriendlySoldiersCount allFriendlySoldiersCount = new UAIV_AllFriendlySoldiersCount(this, _AgentController._PlayerOwner._MaxSoldiers);

        // ****** SCORERS ******
        UtilityScorer scorer_agentHealth = new UtilityScorer(agentHealth, _HealthCurve);
        UtilityScorer scorer_friendlyCount = new UtilityScorer(friendlySoldierCount, _FriendlyAgentsCurve);
        UtilityScorer scorer_enemyCount = new UtilityScorer(enemySoldierCount, _EnemyAgentsCurve);
        UtilityScorer scorer_distanceToEnemy = new UtilityScorer(distanceToEnemy, _AttackDesireCurve);
        UtilityScorer scorer_distanceToEnemyFlee = new UtilityScorer(distanceToEnemy, _FleeDesireCurve);
        UtilityScorer scorer_distanceToFriendlyFlag = new UtilityScorer(distanceToFriendlyFlag, _FriendlyFlagDistanceCurve);
        UtilityScorer scorer_friendlyFlagsCount = new UtilityScorer(friendlyFlagsCount, _FriendlyFlagsForHQAttackCurve);
        UtilityScorer scorer_allFriendlySoldiersCount = new UtilityScorer(allFriendlySoldiersCount, _AllFriendlyAgentsCountCurve);

        // ****** ACTIONS ******
        CaptureFlags captureFlagsAction = new CaptureFlags(capturePointsInScene, this, 0.5f);

        AttackEnemy attackEnemyAction = new AttackEnemy(this, 0.0f);
        attackEnemyAction.AddScorer(scorer_distanceToEnemy);

        Flee fleeAction = new Flee(this, 0.0f);
        fleeAction.AddScorer(scorer_agentHealth);
        fleeAction.AddScorer(scorer_enemyCount);
        fleeAction.AddScorer(scorer_friendlyCount);
        //fleeAction.AddScorer(scorer_distanceToEnemyFlee);

        HealAtFlag healAtFlagAction = new HealAtFlag(this, 0.0f);
        healAtFlagAction.AddScorer(scorer_agentHealth);
        healAtFlagAction.AddScorer(scorer_distanceToFriendlyFlag);
        healAtFlagAction.AddScorer(scorer_distanceToEnemyFlee);

        AttackHQ attackHQAction = new AttackHQ(_AgentController._PlayerOwner._EnemyPlayer, this, 0.0f);
        attackHQAction.AddScorer(scorer_friendlyFlagsCount);
        attackHQAction.AddScorer(scorer_allFriendlySoldiersCount);

        // ****** REGISTER ACTIONS ******
        _AgentActions.Add(captureFlagsAction);
        _AgentActions.Add(attackEnemyAction);
        _AgentActions.Add(fleeAction);
        _AgentActions.Add(healAtFlagAction);
        _AgentActions.Add(attackHQAction);
    }

    // Agent saves all CapturePoints on the map
    private void GetAllCapturePoints()
    {
        capturePointsInScene = new List<GameObject>();
        capturePointsInScene = GameCache._CapturePointsList;
    }
}
