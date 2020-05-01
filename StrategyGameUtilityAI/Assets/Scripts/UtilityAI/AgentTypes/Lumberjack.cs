using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : UtilityAgent
{
    public List<GameObject> Waypoints;

    void Awake()
    {
        AgentActions.Add(new Patrol(Waypoints, 1));
    }
}