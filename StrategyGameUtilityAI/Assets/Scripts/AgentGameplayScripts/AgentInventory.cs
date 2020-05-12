using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Transfer item to another item list
    public void TransferItem(ResourceBase resourceItem, List<ResourceBase> targetInventory)
    {
        if (_resources.Count > 0 && _resources.Contains(resourceItem))
        {
            Remove(resourceItem);
            targetInventory.Add(resourceItem);
        }
    }
}
