using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public event Action onResourceMined;
    public void ResourceMined()
    {
        onResourceMined?.Invoke();
    }
}
