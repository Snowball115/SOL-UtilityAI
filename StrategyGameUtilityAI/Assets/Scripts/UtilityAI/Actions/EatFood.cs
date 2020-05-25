using UnityEngine;

public class EatFood : UtilityAction
{
    private GameObject playerHQ;
    private readonly float reachingHQDistance = 5.0f;


    public EatFood(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Enter()
    {
        base.Enter();

        playerHQ = _agent._AgentController._PlayerOwner.GetBuilding_ByTag("Headquarters");
    }

    public override void Execute()
    {
        base.Enter();

        _agent._AgentController._NavAgent.destination = playerHQ.transform.position;

        if ((playerHQ.transform.position - _agent.transform.position).sqrMagnitude < reachingHQDistance)
        {
            _agent._AgentController.EatFood();
        }
    }
}
