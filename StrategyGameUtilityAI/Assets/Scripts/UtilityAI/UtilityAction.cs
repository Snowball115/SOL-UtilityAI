using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility Action for agents to execute
/// </summary>
[System.Serializable]
public class UtilityAction
{
    // The value the action has
    public float UtilityScore;

    // All scorers that influence the action
    public List<UtilityScorer> Scorers;

    // Should the action be completed before another action begins?
    public bool isInterruptable;
    public bool isActive { get; private set; }

    // The Agent this action can access
    protected UtilityAgent agent;


    public UtilityAction(UtilityAgent agent, float initalScore)
    {
        Scorers = new List<UtilityScorer>();

        this.agent = agent;

        UtilityScore = initalScore;
    }

    // Get the average value of all scorer outcomes
    public void EvaluateAllScorers()
    {
        // Check if any scorers exist
        if (Scorers.Count == 0) return;

        // We don't have to evaluate the whole list if only one scorer exists
        if (Scorers.Count == 1)
        {
            Scorers[0].EvaluateScore();
            UtilityScore = Scorers[0].CurrentScore;
            return;
        }

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
    {
        isActive = true;

        Debug.Log(string.Format("Enter {0}", this.GetType()));
    }

    // Execute state
    public virtual void Execute()
    {
        Debug.Log(string.Format("Running {0}", this.GetType()));
    }

    // Exit state
    public virtual void Exit()
    {
        isActive = false;

        Debug.Log(string.Format("Exit {0}", this.GetType()));
    }
}
