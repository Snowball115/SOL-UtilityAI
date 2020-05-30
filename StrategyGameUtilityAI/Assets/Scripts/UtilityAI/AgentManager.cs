using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    // List of active agents of one manager instance
    public List<UtilityAgent> _ActiveAgents;

    // Control how often the agents update their behaviour
    [SerializeField] private float updateInterval;

    // Timer and bool to control the update loop
    private float intervalTimer;
    private bool isActive;


    void Awake()
    {
        _ActiveAgents = new List<UtilityAgent>();
    }

    private void Start()
    {
        RunAI();
    }

    // Update all agents in a specific interval
    private void Update()
    {
        if (isActive)
        {
            intervalTimer += Time.deltaTime;

            if (intervalTimer > updateInterval)
            {
                UpdateAgents();
                intervalTimer = 0;
            }
        }
    }

    // Run AI process
    public void RunAI()
    {
        isActive = true;
    }

    // Stop AI process
    public void StopAI()
    {
        isActive = false;
    }

    // Add agents to the active list
    public void AddAgentToList(UtilityAgent agent)
    {
        if (!_ActiveAgents.Contains(agent))
        {
            _ActiveAgents.Add(agent);
            return;
        }

        Debug.LogWarning(string.Format("[AgentManager] {0} already in list!", agent.name));
    }

    // Remove agents from list
    public void RemoveAgent(UtilityAgent agent)
    {
        if (_ActiveAgents.Contains(agent))
        {
            _ActiveAgents.Remove(agent);
            return;
        }
        
        Debug.LogWarning(string.Format("[AgentManager] Can't remove {0}!", agent.name));
    }

    // Update agents behaviour
    public void UpdateAgents()
    {
        for (int i = 0; i < _ActiveAgents.Count; i++)
        {
            _ActiveAgents[i].UpdateAgent();
        }
    }
}