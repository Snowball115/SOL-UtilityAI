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

    // Max and current soldiers count
    public int _maxSoldiers { get; private set; }
    public int _CurrentSoldiersCount;


    void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();

        _PlayerBuildings.Add(_PlayerHeadquarters);
    }

    void Start()
    {
        // Spawn 2 agents of each role
        StartCoroutine(SpawnDelayed(1.0f, GameCache._Cache.GetData("Agent-Lumberjack"), _AgentSpawnPos.position));
        StartCoroutine(SpawnDelayed(2.0f, GameCache._Cache.GetData("Agent-Lumberjack"), _AgentSpawnPos.position));
        StartCoroutine(SpawnDelayed(3.0f, GameCache._Cache.GetData("Agent-Miner"), _AgentSpawnPos.position));
        StartCoroutine(SpawnDelayed(4.0f, GameCache._Cache.GetData("Agent-Miner"), _AgentSpawnPos.position));
        StartCoroutine(SpawnDelayed(5.0f, GameCache._Cache.GetData("Agent-Farmer"), _AgentSpawnPos.position));
        StartCoroutine(SpawnDelayed(6.0f, GameCache._Cache.GetData("Agent-Farmer"), _AgentSpawnPos.position));
    }

    void Update()
    {
        //CheckIfSoldierCanSpawn();
    }

    // Spawn agent with delay
    public IEnumerator SpawnDelayed(float seconds, GameObject agent, Vector3 spawnPos)
    {
        yield return new WaitForSeconds(seconds);
        SpawnAgent(agent, spawnPos);
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

    // Instantiate a building
    public void ConstructBuilding(GameObject building, Vector3 targetPos)
    {
        GameObject go = Instantiate(building, targetPos - Vector3.up, Quaternion.identity, _BuildingParentHolder);
        go.name = go.name.Replace("(Clone)", "");
        go.GetComponent<Building>()._PlayerOwner = this;
        _PlayerBuildings.Add(go);
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

    private void CheckIfSoldierCanSpawn()
    {
        while (_CurrentSoldiersCount <= _maxSoldiers)
        {
            //if ()
        }
    }
}
