using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Distance to friendly flag in surrounding
/// </summary>
public class UAIV_DistanceToFriendlyFlag : UtilityValue
{
    private GameObject closestFlag;


    public UAIV_DistanceToFriendlyFlag(UtilityAgent agent, float maxInputValue) : base(agent, maxInputValue) { }

    public override void UpdateCurrentValue()
    {
        base.UpdateCurrentValue();

        // Check if flag is there
        if (_agent._AgentController._Senses.ContainsObject(GameCache._Cache.GetData("CapturePoint")))
        {
            closestFlag = _agent._AgentController._Senses.GetClosestObject(GameCache._Cache.GetData("CapturePoint"));

            // Check if flag belongs to friendly team
            if (closestFlag.GetComponent<CapturePoint>()._TeamOwner != null &&
                closestFlag.GetComponent<CapturePoint>()._TeamOwner._PlayerTeam == _agent._AgentController._Team)
            {
                _CurrentValue = (closestFlag.transform.position - _agent.transform.position).magnitude;
            }
        }

        else _CurrentValue = _MaxValue;
    }
}
