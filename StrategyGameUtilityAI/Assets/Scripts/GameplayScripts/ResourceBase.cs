using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceBase : MonoBehaviour
{
    public enum ResourceType
    {
        WOOD,
        ORE,
        FOOD
    }

    public ResourceType _ResourceType;

    // How many resources can be farmed from this entity
    public int _ResourcePoints;

    public ResourceBase GetMined(int miningPower)
    {
        if (_ResourcePoints <= 0) DestroyEntity();

        _ResourcePoints -= miningPower;

        return this;
    }

    private void DestroyEntity()
    {
        Destroy(this);
    }
}
