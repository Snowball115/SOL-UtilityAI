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

    // Should the action be completed before another action begins?
    public bool isInterruptable;

    // The Agent this action can access
    protected UtilityAgent agent;


    public UtilityAction(UtilityAgent agent, float initalScore)
    {
        Scorers = new List<UtilityScorer>();

        this.agent = agent;

        UtilityScore = initalScore;

        Enter();
    }

    // Get the average value of all scorer outcomes
    public void EvaluateAllScorers()
    {
        // Check if none or only one scorer exists
        if (Scorers.Count <= 1) return;
        Debug.Log("HAHAHA");
        float average = 0;

        for (int i = 0; i < Scorers.Count; i++)
        {
            Scorers[i].EvaluateScore();

            average += Scorers[i].CurrentScore;
        }

        average /= Scorers.Count;

        UtilityScore = average;
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
