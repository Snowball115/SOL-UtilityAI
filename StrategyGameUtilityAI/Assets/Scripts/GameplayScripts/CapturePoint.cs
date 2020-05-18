﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    // The team that controls this CP
    public Player _TeamOwner;

    // The team thats currently capturing the CP
    public Enums.Teams _CurrentCapturerTeam;

    // Progress that controls if a CP is captured
    public float captureProgress;
    private readonly float captureLimit = 100.0f;

    private MeshRenderer flagRenderer;
    private LineRenderer lineRenderer;
    private int segments = 20;

    private bool isCaptured;
    private bool isContested;

    private List<GameObject> agentsInTrigger;

    void Start()
    {
        flagRenderer = GetComponentInChildren<MeshRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.25f;
        DrawCircle();

        agentsInTrigger = new List<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Soldier>())
        {
            // Check if only one team is capturing CP
            agentsInTrigger.Add(other.gameObject);
            _CurrentCapturerTeam = other.GetComponent<Soldier>()._AgentController._Team;
            

            if (isContested) return;

            while (captureProgress < captureLimit)
            {
                captureProgress++;
                return;
            }

            if (_CurrentCapturerTeam == Enums.Teams.BLUE)
            {
                flagRenderer.material.color = Color.blue;
            }
            else
            {
                flagRenderer.material.color = Color.red;
            }

            _TeamOwner = other.GetComponent<Soldier>()._AgentController._PlayerOwner;
        }
    }

    private void DrawCircle()
    {
        float x, z;
        float radius = GetComponent<SphereCollider>().radius;
        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, 0.1f, z));

            angle += (360f / segments);
        }
    }
}