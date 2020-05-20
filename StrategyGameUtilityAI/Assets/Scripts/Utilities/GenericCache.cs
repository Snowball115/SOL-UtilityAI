using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic cache to store and load data
/// </summary>
public class GenericCache<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> cacheDict = new Dictionary<TKey, TValue>();


    // Add item
    public void Add(TKey key, TValue value)
    {
        if (!ContainsKey(key)) cacheDict.Add(key, value);
    }

    // Get value from key
    public TValue GetData(TKey key)
    {
        TValue tmp;

        if (cacheDict.TryGetValue(key, out tmp)) return tmp;

        Debug.LogWarning(string.Format("Data {0} not found", key));

        return tmp;
    }

    // Check if key in dictionary already exists
    private bool ContainsKey(TKey key)
    {
        TValue tmp;

        return cacheDict.TryGetValue(key, out tmp);
    }
}