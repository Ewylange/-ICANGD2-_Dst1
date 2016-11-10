using UnityEngine;
using System.Collections;

public class CameraGyro : MonoBehaviour {

    // Configuration
    [Header("Configuration")]
    public byte gyroscopeFps = 30;

    private void Awake() {
        // Setup gyroscope
        Input.gyro.updateInterval = 1f / (float)gyroscopeFps;
        Input.gyro.enabled = true;
    }

    protected void Update() {
        transform.rotation = Input.gyro.attitude;
        // Swap "handedness" of quaternion from gyro.
        transform.Rotate(0f, 0f, 180f, Space.Self);
        // Rotate to make sense as a camera pointing out the back of your device.
        transform.Rotate(90f, 180f, 0f, Space.World);
    }

}
