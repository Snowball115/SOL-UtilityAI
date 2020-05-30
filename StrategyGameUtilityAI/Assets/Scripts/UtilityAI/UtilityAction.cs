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
    private List<UtilityScorer> _scorers;

    // The Agent this action can access
    protected UtilityAgent _agent;

    // Check if action is active
    public bool isActive { get; private set; }


    public UtilityAction(UtilityAgent agent)
    {
        _scorers = new List<UtilityScorer>();
        _agent = agent;
        _Name = this.GetType().ToString();
    }

    public UtilityAction(UtilityAgent agent, float initalScore)
    {
        _scorers = new List<UtilityScorer>();
        _agent = agent;
        _UtilityScore = initalScore;
        _Name = this.GetType().ToString();
    }

    // Change weight of action
    public void SetWeight(int weight)
    {
        _Weight = weight;
    }

    // Add scorer to this action
    public void AddScorer(UtilityScorer scorer)
    {
        _scorers.Add(scorer);
    }

    // Get the average value of all scorer outcomes
    public void EvaluateAllScorers()
    {
        // Check if any scorers exist
        if (_scorers.Count == 0) return;

        // We don't have to evaluate the whole list if only one scorer exists
        if (_scorers.Count == 1)
        {
            _scorers[0].EvaluateScore();
            _UtilityScore = _scorers[0]._CurrentScore;
            if (_Weight > 0) _UtilityScore *= _Weight;
            return;
        }

        float average = 0;

        // Get average of all scores
        for (int i = 0; i < _scorers.Count; i++)
        {
            _scorers[i].EvaluateScore();

            average += _scorers[i]._CurrentScore;
        }

        average /= _scorers.Count;

        // Apply weight
        if (_Weight != 0) average *= _Weight;

        _UtilityScore = average;
    }

    // Enter action
    public virtual void Enter()
    {
        isActive = true;

        //Debug.Log(string.Format("Enter {0}", this.GetType().ToString()));
    }

    // Execute action
    public virtual void Execute()
    {
        //Debug.Log(string.Format("Running {0}", this.GetType().ToString()));
    }

    // Exit action
    public virtual void Exit()
    {
        isActive = false;

        //Debug.Log(string.Format("Exit {0}", this.GetType().ToString()));
    }
}