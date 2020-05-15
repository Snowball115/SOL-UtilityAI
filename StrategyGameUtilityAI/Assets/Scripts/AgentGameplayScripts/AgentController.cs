﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Enums.Teams Team;

    public Enums.AgentRoles Role;

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
    public float _Health;
    public float _Attack;
    public float _MoveSpeed;
    public float _Food;
    public float _Energy;


    void Awake()
    {
        _NavAgent = GetComponent<NavMeshAgent>();
        _UtilityAgent = GetComponent<UtilityAgent>();
        _Senses = GetComponent<AgentSenses>();
        _Inventory = GetComponent<AgentInventory>();
    }

    void Start()
    {
        _Health = _AgentStats.HealthPoints;
        _Attack = _AgentStats.AttackPoints;
        _MoveSpeed = _AgentStats.MoveSpeed;
        _Food = _AgentStats.FoodPoints;
        _Energy = _AgentStats.EnergyPoints;

        _NavAgent.speed = _MoveSpeed;

        // Change material colour depending on the player team
        if (Team == Enums.Teams.BLUE) GetComponent<MeshRenderer>().material.color = Color.blue;
        else GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        if (_Food > 0) _Food -= 0.05f;

        if (_Energy > 0) _Energy -= 0.02f;
    }
}
