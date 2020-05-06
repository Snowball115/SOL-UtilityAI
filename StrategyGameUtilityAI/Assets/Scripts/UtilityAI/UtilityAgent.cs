using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script for agent to work with Utility AI
/// </summary>
public class UtilityAgent : MonoBehaviour
{
    // Agent gameplay component
    public AgentController AgentController;

    // Agent manager component
    public AgentManager AgentManager;

    // List of availabel actions for the agent
    public List<UtilityAction> AgentActions;

    // Action to use
    public UtilityAction CurrentAction { get; private set; }

    // Own update interval if no Agent Manager is available
    private readonly float customInterval = 0.2f;
    private float intervalTimer;


    void Awake()
    {
        //// Give every action the reference to this agent
        //for (int i = 0; i < AgentActions.Count; i++)
        //{
        //    AgentActions[i].Init(this);
        //}
    }

    protected virtual void Start()
    {
        AgentController = GetComponent<AgentController>();

        AgentActions = new List<UtilityAction>();

        CheckForAgentManager();
    }

    void Update()
    {
        // Will be used if no Agent Manager is available
        if (AgentManager == null)
        {
            intervalTimer += Time.deltaTime;

            if (intervalTimer > customInterval)
            {
                UpdateAgent();
                intervalTimer = 0;
            }
        }
    }

    // Check if AgentManager is available
    private void CheckForAgentManager()
    {
        if (FindObjectOfType<AgentManager>() != null)
        {
            AgentManager = FindObjectOfType<AgentManager>();
            AgentManager.AddAgentToList(this);
            return;
        }

        Debug.LogWarning(string.Format("{0}: Couldn't find AgentManager. Starting custom update loop.", this.name));
    }

    // Update function for our agent
    public void UpdateAgent()
    {
        // Check if any actions for this agent exist
        if (AgentActions.Count == 0) return;

        // Calculate Utility Score of each action
        for (int i = 0; i < AgentActions.Count; i++)
        {
            AgentActions[i].EvaluateAllScorers();
        }
        
        // Choose action with highest utility value
        ChooseAction();

        // Run action
        CurrentAction.Execute();
    }

    // Choose action with highest utility value
    private void ChooseAction()
    {
        // Don't iterate through list if only one action exists
        if (AgentActions.Count == 1)
        {
            CurrentAction = AgentActions[0];
            return;
        }

        float currentScore = 0;
        float deltaScore = 0;

        for (int i = 0; i < AgentActions.Count; i++)
        {
            // Get score of every action in list
            currentScore = AgentActions[i].UtilityScore;

            // Check if previous score is bigger than our score we are currently looking at
            // If yes: We skip to the next score until we find a score which is bigger than our current highest score
            // If no: We have our highest score and can finally execute it
            if (deltaScore > currentScore) continue;

            // Save the current highest score
            deltaScore = currentScore;

            // Assign the best action to our current action to execute
            CurrentAction = AgentActions[i];
        }
    }
}