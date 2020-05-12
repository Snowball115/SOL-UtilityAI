using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility Action for agents to execute
/// </summary>
[System.Serializable]
public class UtilityAction
{
    // Name in editor
    public string _Name;

    // The value the action has
    public float _UtilityScore;

    // Determines how the action should be prioritized over other actions
    public float _Weight;

    // All scorers that influence the action
    public List<UtilityScorer> _Scorers;

    // The Agent this action can access
    protected UtilityAgent _agent;


    public UtilityAction(UtilityAgent agent)
    {
        _Scorers = new List<UtilityScorer>();
        _agent = agent;
        _Name = this.GetType().ToString();
    }

    public UtilityAction(UtilityAgent agent, float initalScore)
    {
        _Scorers = new List<UtilityScorer>();
        _agent = agent;
        _UtilityScore = initalScore;
        _Name = this.GetType().ToString();
    }

    // Add scorer to this action
    public void AddScorer(UtilityScorer scorer)
    {
        _Scorers.Add(scorer);
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
            if (_Weight > 0) _UtilityScore *= _Weight;
            return;
        }

        float average = 0;

        for (int i = 0; i < _Scorers.Count; i++)
        {
            _Scorers[i].EvaluateScore();

            average += _Scorers[i]._CurrentScore;
        }

        // Get average of all scores
        average /= _Scorers.Count;

        // Apply weight
        if (_Weight > 0) average *= _Weight;

        _UtilityScore = average;
    }

    // Execute action
    public virtual void Execute()
    {
        Debug.Log(string.Format("Running {0}", this.GetType()));
    }
}
