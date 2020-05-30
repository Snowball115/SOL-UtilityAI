using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to initialize the game cache
/// </summary>
public class InitGameCache : MonoBehaviour
{
    void Awake()
    {
        GameCache.Instance.Init();
    }
}
