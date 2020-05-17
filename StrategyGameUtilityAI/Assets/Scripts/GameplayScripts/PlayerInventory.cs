﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
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
        if (resources.Count > 0) resources.Remove(resource);
        SubstractResourceCount(resource);
    }

    // Update resource count
    private void UpdateResourceCount(ResourceBase resource)
    {
        if (resource._Type == Enums.ResourceType.WOOD) WoodCount++;
        if (resource._Type == Enums.ResourceType.ORE) OreCount++;
        if (resource._Type == Enums.ResourceType.FOOD) FoodCount++;
    }

    // Update resource count, if removed
    private void SubstractResourceCount(ResourceBase resource)
    {
        if (resource._Type == Enums.ResourceType.WOOD) WoodCount--;
        if (resource._Type == Enums.ResourceType.ORE) OreCount--;
        if (resource._Type == Enums.ResourceType.FOOD) FoodCount--;
    }
}