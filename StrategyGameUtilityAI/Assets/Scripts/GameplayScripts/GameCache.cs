using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCache : Singleton<GameCache>
{
    public static GenericCache<string, GameObject> _Cache = new GenericCache<string, GameObject>();


    public void Init()
    {
        _Cache.Add("Agent-Lumberjack", Resources.Load<GameObject>("Agent-Lumberjack"));
        _Cache.Add("Agent-Miner", Resources.Load<GameObject>("Agent-Miner"));
        _Cache.Add("Agent-Farmer", Resources.Load<GameObject>("Agent-Farmer"));
        _Cache.Add("Agent-Soldier", Resources.Load<GameObject>("Agent-Soldier"));
        _Cache.Add("Tree", Resources.Load<GameObject>("Tree"));
        _Cache.Add("Ore", Resources.Load<GameObject>("Ore"));
        _Cache.Add("Farm", Resources.Load<GameObject>("Farm"));
        _Cache.Add("Lumberyard", Resources.Load<GameObject>("Lumberyard"));
        _Cache.Add("Mine", Resources.Load<GameObject>("Mine"));
        _Cache.Add("Headquarters", Resources.Load<GameObject>("Headquarters"));
    }
}
