using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player team/faction
    public Enums.Teams _PlayerTeam;

    // Position where the agents should spawn at
    public Transform _AgentSpawnPos;

    // Transform that holds all instantiated agents
    public Transform _AgentParentHolder;

    // Agents owned by the player
    public List<GameObject> _PlayerAgents;

    // Buildings owned by the player
    public List<GameObject> _PlayerBuildings;

    // Player inventory
    private PlayerInventory _playerInventory;


    void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();
    }

    void Start()
    {
        SpawnAgent(GameCache._GameCache.GetData("Agent-Lumberjack"), _AgentSpawnPos.position);
        SpawnAgent(GameCache._GameCache.GetData("Agent-Lumberjack"), _AgentSpawnPos.position);
        //SpawnAgent(GameCache._GameCache.GetData("Agent-Miner"), _AgentSpawnPos.position);
        //SpawnAgent(GameCache._GameCache.GetData("Agent-Miner"), _AgentSpawnPos.position);
        //SpawnAgent(GameCache._GameCache.GetData("Agent-Farmer"), _AgentSpawnPos.position);
        //SpawnAgent(GameCache._GameCache.GetData("Agent-Farmer"), _AgentSpawnPos.position);
    }

    // Spawn an agent for this player
    public void SpawnAgent(GameObject agent, Vector3 spawnPos)
    {
        GameObject go = Instantiate(agent, spawnPos, Quaternion.identity, _AgentParentHolder);
        go.GetComponent<AgentController>().Team = _PlayerTeam;
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
}
