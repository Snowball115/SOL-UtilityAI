using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    // Agent gameplay component
    public soAgentStats AgentStats;

    // NavMeshAgent component
    public NavMeshAgent NavAgent { get; private set; }

    // Utility AI component
    public UtilityAgent UtilityAgent { get; private set; }

    // Senses of the agent
    public AgentSenses Senses { get; private set; }

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        UtilityAgent = GetComponent<UtilityAgent>();
        Senses = GetComponent<AgentSenses>();
    }
}
