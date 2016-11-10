using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraManager : MonoBehaviour {

    //private Vector3 originPosition;
    private Quaternion giroscopeRotation;

    [Range(0, 1)]
    public float zoomFactor = 1f;
    public float zoomDistance = 5f;

    private void Awake() {
        //originPosition = transform.position;
        Input.gyro.updateInterval = 0.01f;
        Input.gyro.enabled = true;
    }

    protected void Update() {
        transform.rotation = Input.gyro.attitude;
        Debug.Log(Input.gyro.attitude);
        RefreshZoom();
    }

    public void Slider_zoomRefreshed(float value) {
        zoomFactor = value;
        RefreshZoom();
    }

    public void RefreshZoom() {
        //transform.position = originPosition + Quaternion.LookRotation(transform.forward, Vector3.up) * Vector3.forward * zoomDistance * zoomFactor;
        zoomFactor = Mathf.Clamp01(zoomFactor);
        Camera.main.fieldOfView = Mathf.Lerp(16, 60, zoomFactor);
    }

}