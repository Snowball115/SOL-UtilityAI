using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSenses : MonoBehaviour
{
    // What the agent determines as visible
    public LayerMask _VisibleLayer;

    // How far the agent can see entities
    public float _ViewRange;

    // Storing all visible objects
    public Collider[] _VisibleObjects;

    // Closest entity for the agent
    private GameObject closestObj;
    private Collider closestObjCol;


    void FixedUpdate()
    {
        GetObjectsInView();
    }

    void OnDrawGizmosSelected()
    {
        // Show view range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _ViewRange);

        // Show mining target object
        if (closestObj != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(closestObj.transform.position + Vector3.up, new Vector3(2, 1, 2));
        }

        // Show NavAgent destination
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(GetComponent<NavMeshAgent>().destination + Vector3.up, 1.5f);
    }

    // Get a specific object from array by tag
    public bool ContainsObject(GameObject go)
    {
        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            if (go.CompareTag(_VisibleObjects[i].gameObject.tag)) return true;
        }

        return false;
    }

    // Count specific GameObjects the agent should see
    public int CountObjectsInSight_ByTag(GameObject go)
    {
        int count = 0;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            // Searching by tag because other methods somehow don't work
            if (go.CompareTag(_VisibleObjects[i].gameObject.tag)) count++;
        }

        return count;
    }

    // Count all enemy agent soldiers in area
    public int CountEnemySoldiersInSight()
    {
        Enums.Teams playerTeam = GetComponent<AgentController>()._Team;

        int count = 0;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            if (_VisibleObjects[i].gameObject.GetComponent<Soldier>() != null)
            {
                if (_VisibleObjects[i].gameObject.GetComponent<Soldier>()._AgentController._Team != playerTeam) count++;
            }
        }

        return count;
    }

    // Count all friendly agent soldiers in area
    public int CountFriendlySoldiersInSight()
    {
        Enums.Teams playerTeam = GetComponent<AgentController>()._Team;

        int count = 0;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            if (_VisibleObjects[i].gameObject.GetComponent<Soldier>() != null)
            {
                if (_VisibleObjects[i].gameObject.GetComponent<Soldier>()._AgentController._Team == playerTeam) count++;
            }
        }

        return count;
    }

    // Get closest entity of a specific type
    public GameObject GetClosestObject(GameObject go)
    {
        float distance = 0;
        float tmpDistance = Mathf.Infinity;

        for (int i = 0; i < _VisibleObjects.Length; i++)
        {
            distance = (transform.position - _VisibleObjects[i].transform.position).sqrMagnitude;

            if (distance < tmpDistance && go.CompareTag(_VisibleObjects[i].gameObject.tag))
            {
                tmpDistance = distance;
                closestObjCol = _VisibleObjects[i];
            }
        }

        closestObj = closestObjCol.gameObject;

        return closestObj;
    }

    // Main function to store all visible objects the agent can see
    private void GetObjectsInView()
    {
        _VisibleObjects = Physics.OverlapSphere(transform.position, _ViewRange, _VisibleLayer);
    }
}
