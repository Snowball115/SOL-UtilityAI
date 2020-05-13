using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script for agent to work with Utility AI
/// </summary>
public class UtilityAgent : MonoBehaviour
{
    [Header("---- Agent Data ----")]
    // Agent gameplay component
    public AgentController _AgentController;

    // Agent manager component
    public AgentManager _AgentManager;

    // List of availabel actions for the agent
    public List<UtilityAction> _AgentActions;

    // Action to use
    public UtilityAction _CurrentAction { get; private set; }
    private UtilityAction _oldAction;

    // Own update interval if no Agent Manager is available
    private readonly float _customInterval = 0.2f;
    private float _intervalTimer;


    protected virtual void Start()
    {
        _AgentController = GetComponent<AgentController>();
        _AgentActions = new List<UtilityAction>();

        CheckForAgentManager();
    }

    void Update()
    {
        // Will be used if no Agent Manager is available
        if (_AgentManager == null)
        {
            _intervalTimer += Time.deltaTime;

            if (_intervalTimer > _customInterval)
            {
                UpdateAgent();
                _intervalTimer = 0;
            }
        }
    }

    // Check if AgentManager is available
    private void CheckForAgentManager()
    {
        if (FindObjectOfType<AgentManager>() != null)
        {
            _AgentManager = FindObjectOfType<AgentManager>();
            _AgentManager.AddAgentToList(this);
            return;
        }

        Debug.LogWarning(string.Format("{0}: Couldn't find AgentManager. Starting custom update loop.", this.name));
    }

    // Update function for our agent
    public void UpdateAgent()
    {
        // Check if any actions for this agent exist
        if (_AgentActions.Count == 0) return;

        // Calculate Utility Score of each action
        for (int i = 0; i < _AgentActions.Count; i++)
        {
            _AgentActions[i].EvaluateAllScorers();
        }

        // Call enter state of current action if the action is not active
        if (_CurrentAction != null && !_CurrentAction.isActive) _CurrentAction.Enter();

        ChooseAction();

        // Exit old action
        if (_oldAction != null && _oldAction != _CurrentAction && _oldAction.isActive) _oldAction.Exit();

        // Run action
        _CurrentAction.Execute();
    }

    // Choose action with highest utility value
    private void ChooseAction()
    {
        // Don't iterate through list if only one action exists
        if (_AgentActions.Count == 1)
        {
            _CurrentAction = _AgentActions[0];
            return;
        }

        float currentScore = 0;
        float deltaScore = 0;

        for (int i = 0; i < _AgentActions.Count; i++)
        {
            // Get score of every action in list
            currentScore = _AgentActions[i]._UtilityScore;

            // Check if previous score is bigger than our score we are currently looking at
            // If yes: We skip to the next score until we find a score which is bigger than our current highest score
            // If no: We have our highest score and can finally execute it
            if (deltaScore > currentScore) continue;

            // Save the current highest score
            deltaScore = currentScore;

            // Save old action
            _oldAction = _CurrentAction;

            // Assign the best action to our current action to execute
            _CurrentAction = _AgentActions[i];
        }
    }
}