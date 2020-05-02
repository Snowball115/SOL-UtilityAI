using System.Collections.Generic;
using UnityEngine;

public class Blackboard
{
    private Dictionary<string, object> blackboardData = new Dictionary<string, object>();


    // Shows what data the Dictionary has stored
    public void DebugDict()
    {
        foreach (KeyValuePair<string, object> entry in blackboardData)
        {
            Debug.Log(string.Format("{0} {1}", entry.Key, entry.Value));
        }
    }

    // Adds entry to Dictionary
    public void AddData(string key, object value)
    {
        if (!ContainsKey(key)) blackboardData.Add(key, value);
        else Debug.LogWarning("[BLACKBOARD] Can't add Key that already exists! Consider using ModifyData() instead.");
    }

    // Removes entry from Dictionary
    public void RemoveData(string key)
    {
        if (ContainsKey(key)) blackboardData.Remove(key);
        else Debug.LogWarning("[BLACKBOARD] No key to remove!");
    }

    // Modify an existing value of key
    public void ModifyData(string key, object newValue)
    {
        blackboardData[key] = newValue;
    }

    // Get value from key
    public object GetData(string key)
    {
        object tmp = null;

        if (blackboardData.TryGetValue(key, out tmp))
        {
            return tmp;
        }

        Debug.LogWarning("[BLACKBOARD] Data not found");
        return tmp;
    }

    // Check if key in dictionary already exists
    private bool ContainsKey(string key)
    {
        object tmp = null;
        return blackboardData.TryGetValue(key, out tmp);
    }
}