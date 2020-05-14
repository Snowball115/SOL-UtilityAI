using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Enums.Teams _PlayerTeam;

    public List<AgentController> _PlayerAgents;

    public List<Building> _PlayerBuildings;

    private PlayerInventory _playerInventory;


    private void Awake()
    {
        _playerInventory = GetComponent<PlayerInventory>();
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
