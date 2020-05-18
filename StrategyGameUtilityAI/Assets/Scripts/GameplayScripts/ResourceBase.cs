using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceBase
{
    public Enums.ResourceType _Type;


    public ResourceBase() { }

    public ResourceBase(Enums.ResourceType type)
    {
        _Type = type;
    }
}
