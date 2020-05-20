using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic cache to store data and load it later
/// </summary>
public class GenericCache<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> cacheDict = new Dictionary<TKey, TValue>();


    // Add item
    public void Add(TKey key, TValue value)
    {
        if (!ContainsKey(key)) cacheDict.Add(key, value);

        else Debug.LogWarning("[CACHE] Can't add Key that already exists! Consider using ModifyData() instead.");
    }

    // Remove item
    public void Remove(TKey key)
    {
        if (ContainsKey(key)) cacheDict.Remove(key);

        else Debug.LogWarning("[CACHE] No key to remove!");
    }

    // Modify an existing value of a key
    public void ModifyData(TKey key, TValue newValue)
    {
        cacheDict[key] = newValue;
    }

    // Get value from key
    public TValue GetData(TKey key)
    {
        TValue tmp;

        if (cacheDict.TryGetValue(key, out tmp)) return tmp;

        Debug.LogWarning(string.Format("[CACHE] Data {0} not found", key));

        return tmp;
    }

    // Check if key in dictionary already exists
    private bool ContainsKey(TKey key)
    {
        TValue tmp;

        return cacheDict.TryGetValue(key, out tmp);
    }
}