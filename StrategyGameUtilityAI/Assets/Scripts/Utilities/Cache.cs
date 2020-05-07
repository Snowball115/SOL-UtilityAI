using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic cache class to use for every possible data type
/// </summary>
public class Cache<TKey, TValue>
{
    private Dictionary<TKey, TValue> cacheDict = new Dictionary<TKey, TValue>();

    /// <summary>
    /// Shows what data the Dictionary has stored
    /// </summary>
    public void DebugDict()
    {
        foreach (KeyValuePair<TKey, TValue> entry in cacheDict)
        {
            Debug.Log(string.Format("{0} {1}", entry.Key, entry.Value));
        }
    }

    /// <summary>
    /// Adds entry to Dictionary
    /// </summary>
    public void Add(TKey key, TValue value)
    {
        if (!ContainsKey(key)) 
            cacheDict.Add(key, value);

        else Debug.LogWarning("[CACHE] Can't add Key that already exists! Consider using ModifyData() instead.");
    }

    /// <summary>
    /// Removes entry from Dictionary
    /// </summary>
    public void Remove(TKey key)
    {
        if (ContainsKey(key)) 
            cacheDict.Remove(key);

        else Debug.LogWarning("[CACHE] No key to remove!");
    }

    /// <summary>
    /// Modify an existing value of a key
    /// </summary>
    public void ModifyData(TKey key, TValue newValue)
    {
        cacheDict[key] = newValue;
    }

    /// <summary>
    /// Get value from key
    /// </summary>
    public TValue GetData(TKey key)
    {
        TValue tmp = default(TValue);

        if (cacheDict.TryGetValue(key, out tmp))
        {
            return tmp;
        }

        Debug.LogWarning(string.Format("[CACHE] Data {0} not found", key));

        return tmp;
    }

    /// <summary>
    /// Check if key in dictionary already exists
    /// </summary>
    private bool ContainsKey(TKey key)
    {
        TValue tmp = default(TValue);

        return cacheDict.TryGetValue(key, out tmp);
    }
}