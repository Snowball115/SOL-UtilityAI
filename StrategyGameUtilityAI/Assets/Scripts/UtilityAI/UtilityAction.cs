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
    protected UtilityAgent agent;


    public UtilityAction(UtilityAgent agent, float initalScore)
    {
        this.agent = agent;

        UtilityScore = initalScore;

        Enter();
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
