using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : Building
{
    // Transfer resource to player inventory
    public void AddToPlayerInventory(ResourceBase resource)
    {
        _PlayerOwner._playerInventory.AddResource(resource);
    }
}
