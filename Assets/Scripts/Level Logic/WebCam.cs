using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour 
{
	private WebCamTexture phoneCamera;
	public Color averageColor = Color.white;

	protected void Start() 
	{
		phoneCamera = new WebCamTexture();
		if(WebCamTexture.devices.Length > 0) {
			phoneCamera.Play();
		} else {
			Debug.LogWarning("No webcam device avaiable.");
		}
	}

	protected void Update() 
	{
		if (phoneCamera.isPlaying) 
		{
			averageColor = GetAvreageColorFromWebCamTexture(phoneCamera);
		}
	}

	public Color32 GetAvreageColorFromWebCamTexture(WebCamTexture texture) 
	{
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
}
