﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script for agent to work with Utility AI
/// </summary>
public class UtilityAgent : MonoBehaviour
{
    // Agent gameplay components
    public soAgentStats AgentStats;

    // Agent manager component
    public AgentManager agentManager;

    // List of availabel actions for the agent
    public List<UtilityAction> AgentActions;

    // Action to use
    public UtilityAction currentAction { get; private set; }

    // Own update interval if no Agent Manager is available
    private readonly float customInterval = 0.2f;
    private float intervalTimer;


    void Start()
    {
        CheckForAgentManager();

        // Give every action the reference to this agent
        for (int i = 0; i < AgentActions.Count; i++)
        {
            AgentActions[i].Init(this);
        }
    }

    void Update()
    {
        // Will be used if no Agent Manager is available
        if (agentManager == null)
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
            agentManager = FindObjectOfType<AgentManager>();
            agentManager.AddAgentToList(this);
            return;
        }

        Debug.LogWarning(string.Format("{0}: Couldn't find AgentManager. Starting custom update loop.", this.name));
    }

    // Update function for our agent
    public void UpdateAgent()
    {
        // Check if actions for this agent exist
        if (AgentActions.Count <= 0) return;

        ChooseAction();

        currentAction.Execute();
    }

    // Choose action with highest utility value
    private void ChooseAction()
    {
        float currentScore = 0;
        float deltaScore = 0;

        for (int i = 0; i < AgentActions.Count; i++)
        {
            // Get score of current chosen action
            currentScore = AgentActions[i].UtilityScore;

            // Check if previous score is bigger than our score we are currently looking at
            // If yes: We skip to the next score until we find a score which is bigger than our current highest score
            // If no: We have our highest score and can finally execute it
            if (deltaScore > currentScore) continue;

            // Remember the current highest score
            deltaScore = currentScore;

            // Assign the best action to our current action to execute
            currentAction = AgentActions[i];
        }
    }
}
