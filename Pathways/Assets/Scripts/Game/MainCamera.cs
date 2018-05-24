using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [Header("Player GameObjects")]
    public GameObject player1;
    public GameObject player2;

    [Header("Camera Settings")]
    public float zoomFactor = 1.5f;
    public float followTimeDelta = 0.8f;
    public float minSize = 5f;
    public float distanceBetween;

    private new Camera camera;

    private Transform p1Trans;
    private Transform p2Trans;


    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        // Update Transforms
        p1Trans = player1.transform;
        p2Trans = player2.transform;

        // Find the midpoint between the two player transformations
        Vector3 midpoint = (p1Trans.position + p2Trans.position) / 2f;

        // Find the distance between the two player transformations
        distanceBetween = (p1Trans.position - p2Trans.position).magnitude;

        // Sets the minimum camera distance, so when the players are too close together
        // the camera isnt incredibly close to eachother
        if (distanceBetween < 5f)
            distanceBetween = minSize;

        // Find the appropriate position and distance for the camera to be
        Vector3 cameraDestination = midpoint - camera.transform.forward * distanceBetween * zoomFactor;
        camera.orthographicSize = distanceBetween;
        camera.transform.position = Vector3.Slerp(camera.transform.position, cameraDestination, followTimeDelta);
    }
}