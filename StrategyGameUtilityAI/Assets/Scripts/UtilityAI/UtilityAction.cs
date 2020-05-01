using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility Action for agents to execute
/// </summary>
public class UtilityAction
{
    // The value the action has
    public float UtilityScore;

    // All scorers that influence the action
    public List<UtilityScorer> Scorers;

    // The Agent this action can access
    protected MonoBehaviour agentMB;


    public UtilityAction(MonoBehaviour agentMB, float initalScore)
    {
        this.agentMB = agentMB;

        UtilityScore = initalScore;

        Enter();
    }

    // Get UtilityAgent script for action
    public void Init(MonoBehaviour agentMB)
    {
        
    }

    // Enter state
    public virtual void Enter()
    {}

    // Execute state
    public virtual void Execute()
    {}

    // Exit state
    public virtual void Exit()
    {}
}
