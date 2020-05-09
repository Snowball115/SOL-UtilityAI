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

    // Agent statistics template
    public soAgentStatsTemplate _AgentStats;

    // NavMeshAgent component
    public NavMeshAgent _NavAgent { get; private set; }

    // Utility AI component
    public UtilityAgent _UtilityAgent { get; private set; }

    // Agent senses component
    public AgentSenses _Senses { get; private set; }

    // Data stored from AgentStats template
    public float _Health;
    public float _Attack;
    public float _MoveSpeed;
    public float _Food;
    public float _Energy;

    // Blackboard (Not sure if needed now)
    private Blackboard _bb;


    void Start()
    {
        _NavAgent = GetComponent<NavMeshAgent>();
        _UtilityAgent = GetComponent<UtilityAgent>();
        _Senses = GetComponent<AgentSenses>();

        _Health = _AgentStats.healthPoints;
        _Attack = _AgentStats.attackPoints;
        _MoveSpeed = _AgentStats.moveSpeed;
        _Food = 100.0f;
        _Energy = 100.0f;

        _NavAgent.speed = _MoveSpeed;

        _bb = new Blackboard();
        _bb.AddData("HQ", GameObject.Find("Headquarters"));
    }

    void Update()
    {
        if (_Food > 0) _Food -= 0.05f;

        if (_Energy > 0) _Energy -= 0.02f;
    }
}
