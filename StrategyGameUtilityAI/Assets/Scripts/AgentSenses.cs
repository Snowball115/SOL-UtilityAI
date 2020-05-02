using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSenses : MonoBehaviour
{
    // What the agent determines as visible
    public LayerMask visibleLayer;

    // How far the agent sees objects
    public float ViewRange;

    // All visible objects stored in a list
    public Collider[] VisibleObjects;


    void FixedUpdate()
    {
        GetObjectsInView();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ViewRange);
    }

    private void GetObjectsInView()
    {
        VisibleObjects = Physics.OverlapSphere(transform.position, ViewRange, visibleLayer);
    }

    private void DebugList()
    {
        for (int i = 0; i < VisibleObjects.Length; i++)
        {
            Debug.Log(VisibleObjects[i]);
        }
    }
}
