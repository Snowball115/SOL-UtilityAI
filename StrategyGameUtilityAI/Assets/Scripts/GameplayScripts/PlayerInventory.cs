using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player inventory class
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    // Resources count
    public int WoodCount;
    public int OreCount;
    public int FoodCount;

    private List<ResourceBase> resources;


    void Awake()
    {
        resources = new List<ResourceBase>();
    }

    // Add resource to list
    public void AddResource(ResourceBase resource)
    {
        resources.Add(resource);
        UpdateResourceCount(resource);
    }

    // Remove resource from list
    public void Remove(ResourceBase resource)
    {
        if (resources.Count > 0)
        {
            resources.Remove(resource);
            SubstractResourceCount(resource);
        }
    }

    // Update resource count
    private void UpdateResourceCount(ResourceBase resource)
    {
        switch (resource._Type)
        {
            case Enums.ResourceType.WOOD:
                WoodCount++;
                break;
            case Enums.ResourceType.ORE:
                OreCount++;
                break;
            case Enums.ResourceType.FOOD:
                FoodCount++;
                break;
        }
    }

    // Update resource count, if removed
    private void SubstractResourceCount(ResourceBase resource)
    {
        switch (resource._Type)
        {
            case Enums.ResourceType.WOOD:
                WoodCount--;
                break;
            case Enums.ResourceType.ORE:
                OreCount--;
                break;
            case Enums.ResourceType.FOOD:
                FoodCount--;
                break;
        }
    }
}