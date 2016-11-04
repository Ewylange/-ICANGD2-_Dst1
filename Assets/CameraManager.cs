using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraManager : MonoBehaviour {

    private Vector3 originPosition;
    private Quaternion giroscopeRotation;

    [Range(0, 1)]
    public float zoomFactor = 0f;
    public float zoomDistance = 5f;

    private void Awake() {
        originPosition = transform.position;
    }

    protected  void Update() {
        giroscopeRotation = Input.gyro.attitude;
    }

    public void Slider_zoomRefreshed(float value) {
        zoomFactor = value;
        RefreshZoom();
    }
    
    public void OnPreRender() {
        RefreshRotation();
        RefreshZoom();
    }

    public void RefreshZoom() {
        transform.position = originPosition + Quaternion.LookRotation(transform.forward, Vector3.up) * Vector3.forward * zoomDistance * zoomFactor;
    }

    public void RefreshRotation() {
        transform.rotation = giroscopeRotation;
    }

}