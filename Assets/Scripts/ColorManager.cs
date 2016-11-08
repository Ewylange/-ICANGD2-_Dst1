using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

    private WebCamTexture phoneCamera;

    public Color avreageColor = Color.white;

    // Arch
    public Color archColor = Color.white;

    public bool match = false;

    protected void Start() {
        Debug.Log(WebCamTexture.devices.Length);
        phoneCamera = new WebCamTexture();
        if(WebCamTexture.devices.Length > 0) {
            phoneCamera.Play();
        } else {
            Debug.LogWarning("No webcam device avaiable.");
        }
    }

    protected void Update() {
        // Refresh avreage color
        if (phoneCamera.isPlaying) {
            avreageColor = GetAvreageColorFromWebCamTexture(phoneCamera);
        }

        // Check if avreage color matches arch color
        const float tolerance = 0.25f;
        match = Vector3.Distance((HSVColor)avreageColor, (HSVColor)archColor) <= tolerance;
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
        return new Color32((byte)(r / length), (byte)(g / length), (byte)(b / length), 0);
    }
}
