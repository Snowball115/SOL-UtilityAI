using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// GameCache class to load objects during runtime
/// </summary>
public class GameCache : Singleton<GameCache>
{
    public static GenericCache<string, GameObject> _Cache = new GenericCache<string, GameObject>();

    private static CapturePoint[] _capturePointsInScene;
    public static List<GameObject> _CapturePointsList;

    public void Init()
    {
        // Store prefabs in cache
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

        // Get all CapturePoints in scene
        _capturePointsInScene = MonoBehaviour.FindObjectsOfType<CapturePoint>();
        _CapturePointsList = new List<GameObject>();

        foreach (CapturePoint cp in _capturePointsInScene)
        {
            _CapturePointsList.Add(cp.gameObject);
        }
    }
}
