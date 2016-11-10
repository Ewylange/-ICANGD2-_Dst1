using UnityEngine;
using System.Collections;

public class CameraTravelling : MonoBehaviour {


    // Configuration
    [Header("Configuration")]
    public float travellingDistance = 5f;
    public float travellingDuration = 1f;
    public float delayBetweenTapsForDoubleTap = 0.5f;

    // State
    [Header("Configuration")]
    [System.NonSerialized] private Camera attachedCamera;
    [System.NonSerialized] private CameraController cameraController;
    [System.NonSerialized] private float timeSinceLastTap;

    public struct Request {
        public float distance;
        public float duration;
        public Vector3 direction;

        public Request(float distance, float duration, Vector3 direction) {
            this.distance = distance;
            this.duration = duration;
            this.direction = direction;
        }
    }

    private void Awake() {
        if (attachedCamera == null)
            attachedCamera = GetComponentInChildren<Camera>();
        if (cameraController == null)
            cameraController = GetComponentInParent<CameraController>();
        // Reset time since last tap
        timeSinceLastTap = -delayBetweenTapsForDoubleTap;
    }

    void Update() {
        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0)) {
            if (
                (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) ||
                Input.GetMouseButtonDown(0)
                ) {
                if (Time.time < timeSinceLastTap + delayBetweenTapsForDoubleTap) {
                    // This is a double tap

                    // Make a travelling request
                    MakeTravellingRequest();

                    // Reset time since last tap
                    timeSinceLastTap = -delayBetweenTapsForDoubleTap;
                } else {
                    // This is a regular tap
                    // Set time since last tap
                    timeSinceLastTap = Time.time;
                }
            }
        }
    }

    public bool MakeTravellingRequest() {
        if (cameraController.IsTravelling()) {
            // Cant make a request while the camera is already travelling
            return false;
        }

        // Compute travelling request parameters
        Request travellingRequest = new Request(
            travellingDistance,
            travellingDuration,
            Vector3.ProjectOnPlane(attachedCamera.transform.forward, Vector3.up).normalized
            );

        // Send request
        bool requestWasAccepted =
            cameraController.RequestTravelling(travellingRequest);
        
        return requestWasAccepted;
    }
}
