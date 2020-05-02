using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    // Control how often the agents update their behaviour
    [SerializeField] private float updateInterval;

    // List of active agents of one manager instance
    public List<UtilityAgent> ActiveAgents;

    // Coroutine manager and ticker for update loop
    private CoroutineHelper coroutineHelper;
    private CoroutineTick ticker;


    void Awake()
    {
        ActiveAgents = new List<UtilityAgent>();

        coroutineHelper = FindObjectOfType<CoroutineHelper>();
        ticker = new CoroutineTick();
    }

    private void Start()
    {
        RunAI();
    }

    // Run AI process
    public void RunAI()
    {
        // Update all active agents in a specific interval
        coroutineHelper.Run(ticker.Tick(() => UpdateAgents(), updateInterval), "AgentUpdateLoop");
    }

    // Stop AI process
    public void StopAI()
    {
        coroutineHelper.End("AgentUpdateLoop");
    }

    // Add agents to the active list
    public void AddAgentToList(UtilityAgent agent)
    {
        if (!ActiveAgents.Contains(agent))
        {
            ActiveAgents.Add(agent);
            return;
        }

        Debug.LogWarning(string.Format("[AgentManager] {0} already in list!", agent.name));
    }

    // Remove agents from list
    public void RemoveAgent(UtilityAgent agent)
    {
        if (ActiveAgents.Contains(agent))
        {
            ActiveAgents.Remove(agent);
            return;
        }
        
        Debug.LogWarning(string.Format("[AgentManager] Can't remove {0}!", agent.name));
    }

    // Update agents behaviour
    public void UpdateAgents()
    {
        for (int i = 0; i < ActiveAgents.Count; i++)
        {
            ActiveAgents[i].UpdateAgent();
        }
    }
}
