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
    public GameObject _AgentToObserve;
    public GameObject _NameField;
    public GameObject _ActionNameField;
    public GameObject _ScoreField;

    // Pre caching text fields
    private Text _nameFieldText;
    private Text _actionNameFieldText;
    private Text _scoreFieldText;

    // The Utility Agents data
    private UtilityAgent _agentData;


    void Start()
    {
        _nameFieldText = _NameField.GetComponent<Text>();
        _actionNameFieldText = _ActionNameField.GetComponent<Text>();
        _scoreFieldText = _ScoreField.GetComponent<Text>();

        _agentData = _AgentToObserve.GetComponent<UtilityAgent>();
    }

    void Update()
    {
        _nameFieldText.text = _agentData.gameObject.name;

        if (_agentData._CurrentAction != null)
        {
            _actionNameFieldText.text = _agentData._CurrentAction.ToString();
            //scoreFieldText.text = decimal.Round((decimal)agentData.CurrentAction.UtilityScore, 3).ToString();
            _scoreFieldText.text = _agentData._CurrentAction._UtilityScore.ToString("0.000");
        }
    }
}
