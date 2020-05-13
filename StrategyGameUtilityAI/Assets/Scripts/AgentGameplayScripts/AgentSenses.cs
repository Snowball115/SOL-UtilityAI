using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSenses : MonoBehaviour
{
    // What the agent determines as visible
    public LayerMask _VisibleLayer;

    // How far the agent can see entities
    public float _ViewRange;

    // Storing all visible objects
    public Collider[] _VisibleObjects;


    void FixedUpdate()
    {
        GetObjectsInView();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _ViewRange);
    }

    // Get a specific object from array
    public GameObject GetObject(GameObject go)
    {
        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            if (_VisibleObjects[i].gameObject == go) return go;
        }

        return null;
    }

    // Count specific GameObjects the agent should see
    public int CountObjectsInSight(GameObject go)
    {
        int count = 0;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            //if (_VisibleObjects[i] == go.GetComponent<Collider>()) count++;

            if (Array.Exists(_VisibleObjects, element => element == go)) count++;
        }

        return count;
    }

    // Count specific GameObjects the agent should see, but search with string
    public int CountObjectsInSight(string objectName)
    {
        int count = 0;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            if (_VisibleObjects[i].gameObject.name == objectName) count++;
        }

        return count;
    }

    // Get closest entity of a specific type
    public GameObject GetClosestObject(string objectName)
    {
        GameObject go = null;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {

        }

        return go;
    }

    // Main function to store all visible objects the agent can see
    private void GetObjectsInView()
    {
        _VisibleObjects = Physics.OverlapSphere(transform.position, _ViewRange, _VisibleLayer);
    }

    // Print list of visible objects in console
    private void DebugList()
    {
        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            Debug.Log(_VisibleObjects[i]);
        }
    }
}
