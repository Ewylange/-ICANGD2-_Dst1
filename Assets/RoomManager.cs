using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    // Configuration
    [Header("Configuration")]
    public byte webCamFps = 30;
    public Material colorChangingMaterial;

    public Color roomColor = Color.white;
    [System.NonSerialized] private WebCamTexture webCamTex = null;
    [System.NonSerialized] public static Color averageColor;

    private void Awake() {
        // Setup webcam
        if (WebCamTexture.devices.Length > 0) {
            webCamTex = new WebCamTexture();
            webCamTex.requestedFPS = (float)webCamFps;
            webCamTex.Play();
        } else {
            Debug.LogWarning("No webcam device avaiable.");
        }
    }

    protected void Update() {
        // Refresh avreage color
        if (webCamTex.isPlaying) {
            averageColor = GetAvreageColorFromWebCamTexture(webCamTex);
            RefreshRoomColor();
        }
    }

    public Color32 GetAvreageColorFromWebCamTexture(WebCamTexture texture) {

        // Texture's pixels aray (int)
        Color32[] textureColors32 = texture.GetPixels32();

        // Total RGB
        float r = 0;
        float g = 0;
        float b = 0;

        // Total Pixels
        int length = textureColors32.Length;

        // Get total RGB
        for (int i = 0; i < length; ++i) {
            r += textureColors32[i].r;
            g += textureColors32[i].g;
            b += textureColors32[i].b;
        }

        // Return avreaged color
        return new Color32((byte)(r / length), (byte)(g / length), (byte)(b / length), 255);
    }
    
    public void RefreshRoomColor() {
        roomColor = Vector4.MoveTowards(roomColor, averageColor, Time.deltaTime);

        if (colorChangingMaterial != null) {
            colorChangingMaterial.color = roomColor;
            colorChangingMaterial.SetColor("_EmissionColor", roomColor);
        }
    }

}
