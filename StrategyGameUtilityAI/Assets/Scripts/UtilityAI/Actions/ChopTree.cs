using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : UtilityAction
{
    public ChopTree(float miningRange, UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Execute()
    {
        base.Execute();

        // First check if a lumberyard is placed, if not build one
        if (!_agent.GetComponent<Lumberjack>().isLumberyardPlaced)
        {
            _agent.GetComponent<Lumberjack>().isLumberyardPlaced = true;
            GameObject go = MonoBehaviour.Instantiate(GameCache._GameCache.GetData("Lumberyard"), _agent.transform.position - Vector3.up, Quaternion.identity);
            go.name = go.name.Replace("(Clone)", "");
            _agent._AgentController._PlayerOwner._PlayerBuildings.Add(go);
        }
    }
}
