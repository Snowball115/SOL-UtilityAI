﻿using UnityEngine;

/// <summary>
/// Attack enemy action
/// </summary>
public class AttackEnemy : UtilityAction
{
    private GameObject closestEnemy;
    private GameObject enemyPrefab;


    public AttackEnemy(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        enemyPrefab = GameCache._Cache.GetData("Agent-Soldier");

        // Agent should not run into the enemy
        _agent._AgentController._NavAgent.stoppingDistance = _agent._AgentController._AgentData.AttackRange - 0.1f;
    }

    public override void Execute()
    {
        base.Execute();

        // Check if a enemy is near
        if (_agent._AgentController._Senses.ContainsObject(enemyPrefab))
        {
            closestEnemy = _agent._AgentController._Senses.GetClosestEnemy();

            if (closestEnemy == null) return;

            _agent._AgentController._NavAgent.destination = closestEnemy.transform.position;

            // Attack enemy if close enough
            if ((closestEnemy.transform.position - _agent.transform.position).magnitude < _agent._AgentController._AgentData.AttackRange)
            {
                _agent._AgentController.Attack(_agent._AgentController._AgentData.Attack, closestEnemy);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Stopping distance set to zero to avoid problems with other actions
        _agent._AgentController._NavAgent.stoppingDistance = 0.0f;
    }
}