using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCache : Singleton<GameCache>
{
    public static GenericCache<string, GameObject> _GameCache = new GenericCache<string, GameObject>();


    public void Init()
    {
        _GameCache.Add("Agent-Lumberjack", Resources.Load<GameObject>("Agent-Lumberjack"));
        _GameCache.Add("Agent-Miner", Resources.Load<GameObject>("Agent-Miner"));
        _GameCache.Add("Agent-Farmer", Resources.Load<GameObject>("Agent-Farmer"));
        _GameCache.Add("Tree", Resources.Load<GameObject>("Tree"));
        _GameCache.Add("Ore", Resources.Load<GameObject>("Ore"));
        _GameCache.Add("Field", Resources.Load<GameObject>("Field"));
        _GameCache.Add("Lumberyard", Resources.Load<GameObject>("Lumberyard"));
        _GameCache.Add("Mine", Resources.Load<GameObject>("Mine"));
    }
}
