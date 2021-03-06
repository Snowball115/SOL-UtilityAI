﻿using UnityEngine;

/// <summary>
/// Quick script to control camera in play mode
/// </summary>
public class CameraControl : MonoBehaviour
{
    private float yaw;


    // Move camera towards a position
    private void MoveCamera(Vector3 targetPos)
    {
        transform.position += targetPos * Time.deltaTime * 30;
        transform.position = new Vector3(transform.position.x, 15.0f, transform.position.z);
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) MoveCamera(transform.forward);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) MoveCamera(-transform.forward);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) MoveCamera(-transform.right);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) MoveCamera(transform.right);

        // Rotate camera with mouse
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * 5;
            transform.eulerAngles = new Vector3(40.0f, yaw, 0.0f);
        }
    }
}
