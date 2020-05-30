using UnityEngine;

/// <summary>
/// Move agent to position
/// </summary>
public class MoveTo : UtilityAction
{
    // Position the agent should move at
    public GameObject goalPos;


    public MoveTo(GameObject goalPos, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.goalPos = goalPos;
    }

    public override void Execute()
    {
        base.Execute();

        _agent._AgentController._NavAgent.destination = goalPos.transform.position;
    }
}
