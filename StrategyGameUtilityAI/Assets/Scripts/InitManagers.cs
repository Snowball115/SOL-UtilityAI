using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour
{
    void Awake()
    {
        GameCache.Instance.Init();
    }
}
