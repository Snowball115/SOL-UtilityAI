using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntitiesSpawner : MonoBehaviour
{
    public Transform EntitiesParent;
    public GameObject TreePrefab;
    public GameObject OrePrefab;
    public GameObject CapturePointPrefab;

    [SerializeField] private int treesCount;
    [SerializeField] private int oresCount;
    [SerializeField] private int capturePointsCount;
    [SerializeField] private Vector3 posRangeNormal;
    [SerializeField] private Vector3 posRangeFlags;

    private List<GameObject> activeObjects;
    private Vector3 newPos;


    void Start()
    {
        activeObjects = new List<GameObject>();

        //GenerateEntities();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    for (int i = 0; i < activeObjects.Count; i++)
        //    {
        //        CheckIfObjectsIntersect(activeObjects[i], newPos);
        //    }
        //}
    }

    [ContextMenu("EntitiesSpawner/Generate Entities")]
    public void GenerateEntities()
    {
        for (int i = 0; i < treesCount; i++)
        {
            CreateEntity(TreePrefab, newPos);
        }

        for (int i = 0; i < oresCount; i++)
        {
            CreateEntity(OrePrefab, newPos);
        }

        for (int i = 0; i < capturePointsCount; i++)
        {
            CreateEntity(CapturePointPrefab, newPos);
        }

        for (int i = 0; i < activeObjects.Count; i++)
        {
            if (activeObjects[i] == CapturePointPrefab)
            {
                PlaceEntity(activeObjects[i], newPos, posRangeFlags);
            }

            // Place CPs more in the middle of the map
            PlaceEntity(activeObjects[i], newPos, posRangeNormal);
        }
    }

    [ContextMenu("EntitiesSpawner/Remove Entities")]
    public void RemoveAllEntities()
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            Destroy(activeObjects[i].gameObject);
            activeObjects.RemoveAt(i);
        }
    }

    private void CreateEntity(GameObject go, Vector3 newPos)
    {
        go = Instantiate(go, newPos, Quaternion.identity, EntitiesParent);
        go.name = go.name.Replace("(Clone)", "");
        activeObjects.Add(go);
    }

    private void PlaceEntity(GameObject go, Vector3 newPos, Vector3 rangeVector)
    {
        newPos.x = Random.Range(-rangeVector.x, rangeVector.z);
        newPos.z = Random.Range(-rangeVector.x, rangeVector.z);
        go.transform.position = newPos;
    }

    private void CheckIfObjectsIntersect(GameObject go, Vector3 newPos)
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            if (go.GetComponent<BoxCollider>().bounds.Intersects(activeObjects[i].GetComponent<BoxCollider>().bounds))
            {
                PlaceEntity(go, newPos, posRangeNormal);
            }
        }
    }
}
