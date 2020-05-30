using UnityEngine;

/// <summary>
/// Simple script to rotate the agent's UI canvas towards the player's camera
/// </summary>
public class CanvasCamera : MonoBehaviour
{
    private Camera cam;


    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, Vector3.up);
    }
}