using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : UtilityAction
{
    private GameObject closestTree;
    private Vector3 lumberyardPos;
    private bool isLumberyardPlaced;


    public ChopTree(float miningRange, UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Execute()
    {
        base.Execute();

        if (!isLumberyardPlaced)
        {
            isLumberyardPlaced = true;
            GameObject go = MonoBehaviour.Instantiate(GameCache._GameCache.GetData("Lumberyard"));
            lumberyardPos = go.transform.position;
        }

        
    }
}
