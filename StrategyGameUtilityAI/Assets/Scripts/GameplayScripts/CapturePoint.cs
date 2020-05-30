using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Capture Point class (Flags the agent can capture)
/// </summary>
public class CapturePoint : MonoBehaviour
{
    // Image that shows visual capture progress
    public GameObject ProgressBar;
    private Image progressBarImage;

    // The team that controls this CP
    public Player _TeamOwner;

    // The team thats currently capturing the CP
    public Enums.Teams _CurrentCapturerTeam;

    // Progress that controls if CP is captured
    [SerializeField] private float captureProgress;
    private readonly float captureLimit = 10.0f;

    // All agents that are trying to capture the CP
    public List<GameObject> agentsInTrigger;

    // Flag and circle graphics
    private MeshRenderer flagRenderer;
    private LineRenderer lineRenderer;
    private readonly int circlePoints = 40;

    // Check if CP is captured by a team
    private bool isCaptured;

    // Check if two factions are fighting in the CP's radius
    private bool isContested;


    void Start()
    {
        progressBarImage = ProgressBar.GetComponent<Image>();
        ProgressBar.SetActive(false);

        flagRenderer = GetComponentInChildren<MeshRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = circlePoints + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.25f;
        lineRenderer.material.color = Color.white;
        DrawCircle();

        agentsInTrigger = new List<GameObject>();
    }

    void Update()
    {
        // Remove agent if he dies while staying in the CPs trigger radius
        for (int i = 0; i < agentsInTrigger.Count; i++)
        {
            if (agentsInTrigger[i] == null) agentsInTrigger.RemoveAt(i);
        }

        // Update capture progress bar
        if (ProgressBar.activeInHierarchy) progressBarImage.fillAmount = captureProgress / captureLimit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Soldier>())
        {
            // Add agent to list if he steps into the trigger
            agentsInTrigger.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Soldier>())
        {
            // Get the current team that captures the CP
            _CurrentCapturerTeam = other.GetComponent<Soldier>()._AgentController._Team;

            // Don't capture again if CP is already captured by the team that's standing in the CP
            if (isCaptured && _CurrentCapturerTeam == _TeamOwner._PlayerTeam) return;

            // Check if only one team is capturing CP
            if (agentsInTrigger.Count > 1)
            {
                for (int i = 0; i < agentsInTrigger.Count; i++)
                {
                    // Check if opposite team is trying to capture flag while staying at CP
                    if (agentsInTrigger[i].GetComponent<AgentController>()._Team != _CurrentCapturerTeam)
                    {
                        isContested = true;
                        lineRenderer.material.color = Color.yellow;
                        return;
                    }
                }
            }

            isContested = false;

            // Show progress bar and set line to green
            ProgressBar.SetActive(true);
            lineRenderer.material.color = Color.green;

            // Capturing progress
            while (captureProgress < captureLimit)
            {
                captureProgress += Time.deltaTime;
                return;
            }

            captureProgress = 0f;
            isCaptured = true;

            // Set flag color
            switch (_CurrentCapturerTeam)
            {
                case Enums.Teams.BLUE:
                    flagRenderer.material.color = Color.blue;
                    lineRenderer.material.color = Color.blue;
                    break;

                case Enums.Teams.RED:
                    flagRenderer.material.color = Color.red;
                    lineRenderer.material.color = Color.red;
                    break;
            }

            ProgressBar.SetActive(false);

            if (other.GetComponent<Soldier>() == null) return;

            // Remove flag from the possession of the previous player
            if (_TeamOwner != null) _TeamOwner._CapturedCPs.Remove(this.gameObject);

            // Save player that captured the flag
            _TeamOwner = other.GetComponent<Soldier>()._AgentController._PlayerOwner;
            _TeamOwner._CapturedCPs.Add(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Soldier>() && agentsInTrigger.Contains(other.gameObject))
        {
            // Remove agent if he leaves trigger
            agentsInTrigger.Remove(other.gameObject);

            // Safety checks for flag and trigger color
            if (_TeamOwner == null)
            {
                lineRenderer.material.color = Color.white;
                return;
            }

            switch (_TeamOwner._PlayerTeam)
            {
                case Enums.Teams.BLUE:
                    lineRenderer.material.color = Color.blue;
                    break;

                case Enums.Teams.RED:
                    lineRenderer.material.color = Color.red;
                    break;   
            }
        }
    }

    // Let the LineRenderer draw a circle around the CP
    private void DrawCircle()
    {
        float xPos, zPos;
        float radius = GetComponent<SphereCollider>().radius;
        float angle = 20f;

        for (int i = 0; i < (circlePoints + 1); i++)
        {
            xPos = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            zPos = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(xPos, 0.1f, zPos));

            angle += (360f / circlePoints);
        }
    }
}