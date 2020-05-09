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
    public float _UtilityScore;

    // Determines how the action should be prioritized over other actions
    public float _Weight;

    // All scorers that influence the action
    public List<UtilityScorer> _Scorers;

    // The Agent this action can access
    protected UtilityAgent _agent;


    public UtilityAction(UtilityAgent agent, float initalScore)
    {
        _Scorers = new List<UtilityScorer>();

        _agent = agent;

        _UtilityScore = initalScore;
    }

    // Get the average value of all scorer outcomes
    public void EvaluateAllScorers()
    {
        // Check if any scorers exist
        if (_Scorers.Count == 0) return;

        // We don't have to evaluate the whole list if only one scorer exists
        if (_Scorers.Count == 1)
        {
            _Scorers[0].EvaluateScore();
            _UtilityScore = _Scorers[0]._CurrentScore;
            return;
        }

        float average = 0;

        for (int i = 0; i < _Scorers.Count; i++)
        {
            _Scorers[i].EvaluateScore();

            average += _Scorers[i]._CurrentScore;
        }

        average /= _Scorers.Count;

        _UtilityScore = average;

        // Apply weight if weight is not null
        if (_Weight != 0) _UtilityScore *= _Weight;
    }

    // Execute action
    public virtual void Execute()
    {
        Debug.Log(string.Format("Running {0}", this.GetType()));
    }
}
