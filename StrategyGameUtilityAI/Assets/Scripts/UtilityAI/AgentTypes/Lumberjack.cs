using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : UtilityAgent
{
    void Awake()
    {
        AgentActions.Add(new MoveTo(GameObject.Find("PositionA"), 1));
        AgentActions.Add(new MoveTo(GameObject.Find("PositionB"), 1));
        AgentActions.Add(new MoveTo(GameObject.Find("PositionC"), 1));
    }
}