using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The headquarters of this player faction
    public GameObject _PlayerHeadquarters;

    // Player team/faction
    public Enums.Teams _PlayerTeam;

    // Position where the agents should spawn at
    public Transform _AgentSpawnPos;

    // Transform that holds all instantiated agents
    public Transform _AgentParentHolder;

    // Tranform that hold all instantiated buildings
    public Transform _BuildingParentHolder;

    // Agents owned by the player
    public List<GameObject> _PlayerAgents;

    // Buildings owned by the player
    public List<GameObject> _PlayerBuildings;

    // Player inventory
    public PlayerInventory _playerInventory { get; private set; }


    void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();

        _PlayerBuildings.Add(_PlayerHeadquarters);
    }

    void Start()
    {
        // Spawn 2 agents of each role
        SpawnAgent(GameCache._Cache.GetData("Agent-Lumberjack"), _AgentSpawnPos.position);
        SpawnAgent(GameCache._Cache.GetData("Agent-Lumberjack"), _AgentSpawnPos.position);
        SpawnAgent(GameCache._Cache.GetData("Agent-Miner"), _AgentSpawnPos.position);
        SpawnAgent(GameCache._Cache.GetData("Agent-Miner"), _AgentSpawnPos.position);
        SpawnAgent(GameCache._Cache.GetData("Agent-Farmer"), _AgentSpawnPos.position);
        SpawnAgent(GameCache._Cache.GetData("Agent-Farmer"), _AgentSpawnPos.position);
    }

    // Spawn an agent for this player
    public void SpawnAgent(GameObject agent, Vector3 spawnPos)
    {
        GameObject go = Instantiate(agent, spawnPos, Quaternion.identity, _AgentParentHolder);
        go.GetComponent<AgentController>()._Team = _PlayerTeam;
        go.GetComponent<AgentController>()._PlayerOwner = this;
        go.name = go.name.Replace("(Clone)", "");
        _PlayerAgents.Add(go);
    }

    // Add resource to inventory
    public void AddToInventory(ResourceBase resource)
    {
        _playerInventory.AddResource(resource);
    }

    // Remove resource from inventory
    public void RemoveFromInventory(ResourceBase resource)
    {
        _playerInventory.Remove(resource);
    }

    // Return a specific building from building list
    public GameObject GetBuilding_ByTag(string objectTag)
    {
        if (_PlayerBuildings.Count > 0)
        {
            for (int i = 0; i < _PlayerBuildings.Count; i++)
            {
                if (_PlayerBuildings[i].CompareTag(objectTag)) return _PlayerBuildings[i].gameObject;
            }
        }

        return null;
    }
}
