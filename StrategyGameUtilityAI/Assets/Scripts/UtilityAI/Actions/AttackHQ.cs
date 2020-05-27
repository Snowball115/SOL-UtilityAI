using UnityEngine;

/// <summary>
/// Attack the hostile Headquarters
/// </summary>
public class AttackHQ : UtilityAction
{
    private GameObject enemyHQ;
    private GameObject enemyPlayer;


    public AttackHQ(GameObject enemyPlayer, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.enemyPlayer = enemyPlayer;
    }

    public override void Enter()
    {
        base.Enter();

        // Agent should not run into the enemy
        _agent._AgentController._NavAgent.stoppingDistance = _agent._AgentController._AgentData.AttackRange - 0.1f;
    }

    public override void Execute()
    {
        base.Execute();

        enemyHQ = enemyPlayer.GetComponent<Player>()._PlayerHeadquarters;

        _agent._AgentController._NavAgent.destination = enemyHQ.transform.position;

        // Attack if HQ is close enough
        if ((enemyHQ.transform.position - _agent.transform.position).magnitude < _agent._AgentController._AgentData.AttackRange)
        {
            _agent._AgentController.Attack(_agent._AgentController._AgentData.Attack, enemyHQ);
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Stopping distance set to zero to avoid problems with other actions
        _agent._AgentController._NavAgent.stoppingDistance = 0.0f;
    }
}