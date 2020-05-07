using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCache : Singleton<GameCache>
{
    public static Cache<string, GameObject> _GameCache = new Cache<string, GameObject>();


    public void Init()
    {
        _GameCache.Add("Tree", Resources.Load<GameObject>("Tree"));
        _GameCache.Add("Ore", Resources.Load<GameObject>("Ore"));
        _GameCache.Add("Field", Resources.Load<GameObject>("Field"));
        _GameCache.Add("WoodWarehouse", Resources.Load<GameObject>("WoodWarehouse"));
        _GameCache.Add("Mine", Resources.Load<GameObject>("Mine"));
    }
}
