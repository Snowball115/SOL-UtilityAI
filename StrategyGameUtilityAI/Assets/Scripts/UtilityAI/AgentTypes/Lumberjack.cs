using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : UtilityAgent
{
    public List<GameObject> Waypoints;


    void Start()
    {
        AgentActions.Add(new Patrol(Waypoints, this, 1));
    }
}