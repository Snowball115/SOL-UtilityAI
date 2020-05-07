using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSenses : MonoBehaviour
{
    // What the agent determines as visible
    public LayerMask _VisibleLayer;

    // How far the agent sees objects
    public float _ViewRange;

    // All visible objects stored in a list
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

    // Get number of specific objects the agent should see
    public int GetObjectsInSightCount(GameObject go)
    {
        int count = 0;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            if (_VisibleObjects[i] == go) count++;
        }

        return count;
    }

    // Store all visible objects the agent can see
    private void GetObjectsInView()
    {
        _VisibleObjects = Physics.OverlapSphere(transform.position, _ViewRange, _VisibleLayer);
    }

    // Show list of visible objects
    private void DebugList()
    {
        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            Debug.Log(_VisibleObjects[i]);
        }
    }
}
