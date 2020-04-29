using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helper class to handle coroutines more easily
/// </summary>
public class CoroutineHelper : MonoBehaviour
{
    private Dictionary<string, IEnumerator> activeCoroutines = new Dictionary<string, IEnumerator>();

    /// <summary>
    /// Run coroutine once without checking if coroutine already exists
    /// </summary>
    public void RunOnce(IEnumerator coroutine)
    {
        StartCR(coroutine);
    }

    /// <summary>
    /// Register in list and run coroutine
    /// </summary>
    public void Run(IEnumerator coroutine, string name)
    {
        if (!CheckIfCoroutineExists(name))
        {
            IEnumerator cr = coroutine;
            activeCoroutines.Add(name, cr);
            StartCR(cr);
            return;
        }

        Debug.LogWarning(string.Format("[CoroutineHelper] RUN(): {0} already exists!", name));
    }

    /// <summary>
    /// Search for registered coroutine to stop it
    /// </summary>
    public void End(string name)
    {
        if (CheckIfCoroutineExists(name))
        {
            IEnumerator cr = GetEntry(name);
            activeCoroutines.Remove(name);
            StopCR(cr);
            return;
        }

        Debug.LogWarning(string.Format("[CoroutineHelper] END(): {0} not found!", name));
    }

    /// <summary>
    /// Show all current coroutines running
    /// </summary>
    public void DebugList()
    {
        foreach (KeyValuePair<string, IEnumerator> item in activeCoroutines)
            Debug.LogFormat("{0}", item.ToString());
    }

    private bool CheckIfCoroutineExists(string name)
    {
        IEnumerator tmp;
        return activeCoroutines.TryGetValue(name, out tmp);
    }

    private IEnumerator GetEntry(string name)
    {
        IEnumerator tmp;
        activeCoroutines.TryGetValue(name, out tmp);
        return tmp;
    }

    private void StartCR(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    private void StopCR(IEnumerator coroutine) 
    {
        StopCoroutine(coroutine);
    }
}
