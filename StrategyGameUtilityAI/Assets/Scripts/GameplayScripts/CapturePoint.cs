﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private MeshRenderer flagRenderer;
    private LineRenderer lineRenderer;
    private readonly int circlePoints = 40;

    // Check if CP is captured by a team
    private bool isCaptured;

    // Check if two factions are fighting in the CP's radius
    private bool isContested;

    public List<GameObject> agentsInTrigger;

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
        progressBarImage.fillAmount = captureProgress / captureLimit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Soldier>())
        {
            agentsInTrigger.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Soldier>())
        {
            // Get the current team that captures the CP
            _CurrentCapturerTeam = other.GetComponent<Soldier>()._AgentController._Team;

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

            // Don't capture again if CP is already captured by the team that's standing in the CP
            if (isCaptured && _CurrentCapturerTeam == _TeamOwner._PlayerTeam) return;

            ProgressBar.SetActive(true);
            lineRenderer.material.color = Color.green;

            while (captureProgress < captureLimit)
            {
                captureProgress += Time.deltaTime;
                return;
            }

            captureProgress = 0f;
            isCaptured = true;

            switch (_CurrentCapturerTeam)
            {
                case Enums.Teams.BLUE:
                    flagRenderer.material.color = Color.blue;
                    break;

                case Enums.Teams.RED:
                    flagRenderer.material.color = Color.red;
                    break;
            }

            _TeamOwner = other.GetComponent<Soldier>()._AgentController._PlayerOwner;

            ProgressBar.SetActive(false);
            lineRenderer.material.color = Color.white;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Soldier>() && agentsInTrigger.Contains(other.gameObject))
        {
            agentsInTrigger.Remove(other.gameObject);

            if (agentsInTrigger.Count == 0) lineRenderer.material.color = Color.white;
        }
    }

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