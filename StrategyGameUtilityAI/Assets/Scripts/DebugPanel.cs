using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple debug info to show above the agent's UI
/// </summary>
public class DebugPanel : MonoBehaviour
{
    // Fields in editor
    public GameObject AgentToObserve;
    public GameObject NameField;
    public GameObject ActionNameField;
    public GameObject ScoreField;

    // Pre caching text fields
    private Text nameFieldText;
    private Text actionNameFieldText;
    private Text scoreFieldText;

    // The Utility Agents data
    private UtilityAgent agentData;


    void Start()
    {
        nameFieldText = NameField.GetComponent<Text>();
        actionNameFieldText = ActionNameField.GetComponent<Text>();
        scoreFieldText = ScoreField.GetComponent<Text>();

        agentData = AgentToObserve.GetComponent<UtilityAgent>();
    }

    void Update()
    {
        nameFieldText.text = agentData.gameObject.name;

        if (agentData.CurrentAction != null)
        {
            actionNameFieldText.text = agentData.CurrentAction.ToString();
            scoreFieldText.text = agentData.CurrentAction.UtilityScore.ToString();
        }
    }
}
