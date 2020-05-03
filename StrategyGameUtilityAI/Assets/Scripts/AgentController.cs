using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public enum AgentRole
    {
        LUMBERJACK,
        MINER,
        FARMER,
        SOLDIER
    }

    public AgentRole Role;

    // Agent statistics component
    public soAgentStats _AgentStats;

    // NavMeshAgent component
    public NavMeshAgent _NavAgent { get; private set; }

    // Utility AI component
    public UtilityAgent _UtilityAgent { get; private set; }

    // Agent senses component
    public AgentSenses _Senses { get; private set; }


    void Start()
    {
        _NavAgent = GetComponent<NavMeshAgent>();
        _UtilityAgent = GetComponent<UtilityAgent>();
        _Senses = GetComponent<AgentSenses>();
    }
}
