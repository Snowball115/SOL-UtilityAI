using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : UtilityAction
{
    private GameObject targetToFleeFrom;
    private Vector3 fleePos;


    public Flee(GameObject targetToFleeFrom, UtilityAgent agent, float initialScore) : base(agent, initialScore)
    {
        this.targetToFleeFrom = targetToFleeFrom;
    }

    public override void Execute()
    {
        base.Execute();

        float distance = (targetToFleeFrom.transform.position - _agent.transform.position).sqrMagnitude;


    }
}
