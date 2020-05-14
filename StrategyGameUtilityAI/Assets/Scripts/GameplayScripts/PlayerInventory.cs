using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int WoodCount;
    public int OreCount;
    public int FoodCount;

    private List<ResourceBase> resources;
    private ResourceBase.ResourceType type;


    void Awake()
    {
        resources = new List<ResourceBase>();
    }

    // Update inventory content count
    void Update()
    {
        if (resources.Count > 0)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                switch (type)
                {
                    case ResourceBase.ResourceType.WOOD:
                        WoodCount++;
                        break;

                    case ResourceBase.ResourceType.ORE:
                        OreCount++;
                        break;

                    case ResourceBase.ResourceType.FOOD:
                        FoodCount++;
                        break;
                }
            }
        }
    }

    // Add resource to list
    public void AddResource(ResourceBase resource)
    {
        resources.Add(resource);
    }

    // Remove resource from list
    public void Remove(ResourceBase resource)
    {
        if (resources.Count > 0) resources.Remove(resource);
    }
}