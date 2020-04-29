using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple debug info to show above the agent's UI
/// </summary>
public class DebugPanel : MonoBehaviour
{
    public GameObject agentToObserve;
    public GameObject agentNameField;
    public GameObject agentActionNameField;

    private UtilityAgent agentData;

    void Start()
    {
        agentData = agentToObserve.GetComponent<UtilityAgent>();
    }

    void Update()
    {
        agentNameField.GetComponent<Text>().text = agentData.gameObject.name;

        if (agentData.currentAction != null)
            agentActionNameField.GetComponent<Text>().text = agentData.currentAction.ToString();
    }
}
