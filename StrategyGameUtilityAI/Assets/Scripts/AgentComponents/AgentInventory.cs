using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Agent inventory to store resources
/// </summary>
public class AgentInventory : MonoBehaviour
{
    // Max size of inventory
    public int _MaxInventorySize;

    // All resources the agent can carry
    [SerializeField] private List<ResourceBase> _resources;


    void Start()
    {
        _resources = new List<ResourceBase>();
    }

    // Count amount of objects in inventory
    public int GetCurrentInventorySize()
    {
        int count = 0;

        for (int i = 0; i < _resources.Count; i++)
        {
            if (_resources[i] != null) count++;
        }

        return count;
    }

    // Add resource to inventory
    public void Add(ResourceBase resourceItem)
    {
        if (_resources.Count < _MaxInventorySize)
        {
            _resources.Add(resourceItem);
        }
    }

    // Remove resource from inventory
    public void Remove(ResourceBase resourceItem)
    {
        if (_resources.Contains(resourceItem))
        {
            _resources.Remove(resourceItem);
        }
    }

    // Transfer item to player inventory
    public void TransferItems(Player targetInventory)
    {
        while (_resources.Count > 0)
        {
            targetInventory.AddToInventory(_resources[0]._Type);
            Remove(_resources[0]);
        }
    }
}