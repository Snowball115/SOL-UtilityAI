using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnititiesSpawner : MonoBehaviour
{
    public Transform EntitiesParent;
    public GameObject TreePrefab;
    public GameObject OrePrefab;
    public GameObject CapturePointPrefab;

    [SerializeField] private int treesCount;
    [SerializeField] private int oresCount;
    [SerializeField] private int capturePointsCount;
    [SerializeField] private int rangeX;
    [SerializeField] private int rangeZ;

    private List<GameObject> activeObjects;
    private Vector3 newPos;

    void Start()
    {
        activeObjects = new List<GameObject>();

        GenerateEntities();
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
            PlaceEntity(activeObjects[i], newPos);
        }
    }

    private void CreateEntity(GameObject go, Vector3 newPos)
    {
        go = Instantiate(go, newPos, Quaternion.identity, EntitiesParent);
        go.name = go.name.Replace("(Clone)", "");
        activeObjects.Add(go);
    }

    private void PlaceEntity(GameObject go, Vector3 newPos)
    {
        newPos.x = Random.Range(-rangeX, rangeX);
        newPos.z = Random.Range(-rangeZ, rangeZ);
        go.transform.position = newPos;
    }

    private void CheckIfObjectsIntersect(GameObject go, Vector3 newPos)
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            if (!go.GetComponent<BoxCollider>().bounds.Intersects(activeObjects[i].GetComponent<BoxCollider>().bounds))
            {
                PlaceEntity(go, newPos);
            }
        }
    }
}
