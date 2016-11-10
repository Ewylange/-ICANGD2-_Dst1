using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
    
    // Configuration
    [System.Serializable]
    public struct FovConfig {
        [Range(1, 179)]
        public float closest;
        [Range(1, 179)]
        public float farthest;
        
        public FovConfig(float closest, float farthest) {
            this.closest = closest;
            this.farthest = farthest;
        }
    }
    [Header("Configuration")]
    public FovConfig fov = new FovConfig(16, 60);
    public AnimationCurve curve = AnimationCurve.Linear(0,0,1,1);
    public float sensibility = 0.01f;

    // Inspector
    [Header("Edition")]
    [Range(0, 1)]
    public float zoomFactor = 0f;

    // State
    [System.NonSerialized] private Camera attachedCamera;
    [System.NonSerialized] float lastABDist = -1;

    // Inspector
    void OnValidate() {
        if (attachedCamera == null)
            attachedCamera = GetComponentInChildren<Camera>();
        ApplyZoom();
    }
    
    private void Awake() {
        if (attachedCamera == null)
            attachedCamera = GetComponentInChildren<Camera>();
    }

    void Update() {
        // Check if more than two fingers on screen
        if (Input.touchCount == 2) {
            // Retrieve distance between both fingers
            Touch touchA = Input.GetTouch(0);
            Touch touchB = Input.GetTouch(1);
            float newABDist = Vector2.Distance(touchA.position, touchB.position);

            // Wait next frame if this is the first zoom (double touch) input frame
            if (lastABDist < 0) {
                lastABDist = newABDist;
                return;
            }

            // Calculate if both fingers are geting closer or away from each other
            float deltaDist = newABDist - lastABDist;

            // Apply this change to the current zoom factor
            zoomFactor += deltaDist * sensibility * Time.deltaTime;
            zoomFactor = Mathf.Clamp01(zoomFactor);

            // Apply camera zoom
            ApplyZoom();

        } else {
            // Indicate there weren't zoom (double touch) input last frame
            lastABDist = -1;
        }
    }

    public void ApplyZoom() {
        // Apply current zoom factor onto the attached camera
        attachedCamera.fieldOfView = Mathf.Lerp(fov.farthest, fov.closest, curve.Evaluate(zoomFactor));
    }
}
