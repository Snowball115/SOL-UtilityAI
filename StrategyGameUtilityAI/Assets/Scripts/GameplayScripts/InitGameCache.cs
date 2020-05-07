using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameCache : MonoBehaviour
{
    void Awake()
    {
        GameCache.Instance.Init();
    }
}
