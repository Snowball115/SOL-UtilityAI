using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Enums.Teams _Team;

    public Enums.AgentRoles _Role;

    // The player to which this agent belongs
    public Player _PlayerOwner;

    // Agent statistics template
    public soAgentStatsTemplate _AgentStats;

    // NavMeshAgent component
    public NavMeshAgent _NavAgent { get; private set; }

    // Utility AI component
    public UtilityAgent _UtilityAgent { get; private set; }

    // Agent senses component
    public AgentSenses _Senses { get; private set; }

    // Agent inventory component
    public AgentInventory _Inventory { get; private set; }

    // Data stored from AgentStats template
    public struct AgentData
    {
        public float Health;
        public float Attack;
        public float MoveSpeed;
        public float Food;
        public float Energy;
    };

    public AgentData _AgentData;


    void Awake()
    {
        _NavAgent = GetComponent<NavMeshAgent>();
        _UtilityAgent = GetComponent<UtilityAgent>();
        _Senses = GetComponent<AgentSenses>();
        _Inventory = GetComponent<AgentInventory>();
    }

    void Start()
    {
        _AgentData.Health = _AgentStats.HealthPoints;
        _AgentData.Attack = _AgentStats.AttackPoints;
        _AgentData.MoveSpeed = _AgentStats.MoveSpeed;
        _AgentData.Food = _AgentStats.FoodPoints;
        _AgentData.Energy = _AgentStats.EnergyPoints;

        _NavAgent.speed = _AgentData.MoveSpeed;

        // Change material colour depending on the player team
        if (_Team == Enums.Teams.BLUE) GetComponent<MeshRenderer>().material.color = Color.blue;
        else GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        if (_AgentData.Food > 0) _AgentData.Food -= 0.01f;

        //if (_AgentData.Energy > 0) _AgentData.Energy -= 0.02f;
    }
}
