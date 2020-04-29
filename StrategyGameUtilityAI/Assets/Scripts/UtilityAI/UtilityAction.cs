using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility Action for agents to execute
/// </summary>
public class UtilityAction : ScriptableObject
{
    // The value the action has
    public float UtilityScore;

    // All scorers that influence the action
    public List<UtilityScorer> Scorers;

    // The Agent this action can access
    protected UtilityAgent agent;


    // Get UtilityAgent script for action
    public void Init(UtilityAgent agent)
    {
        this.agent = agent;

        Setup();
    }

    // Setup action
    public virtual void Setup()
    {}

    // Execute action
    public virtual void Execute()
    {}
}
