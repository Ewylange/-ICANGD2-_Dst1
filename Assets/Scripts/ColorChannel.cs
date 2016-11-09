using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorChannel : MonoBehaviour 
{
	public WebCam webCam;
	public string colorChannel;
	Color averageColor;

	protected void Update() 
	{
		averageColor = webCam.averageColor;
		if(colorChannel == "Red")
		{
			GetComponent<Renderer>().material.color = new Color(1, 1 - averageColor.r, 1 - averageColor.r, averageColor.a);
		}
		if(colorChannel == "Green")
		{
			GetComponent<Renderer>().material.color = new Color(1 - averageColor.g, 1, 1 - averageColor.g, averageColor.a);
		}
		if(colorChannel == "Blue")
		{
			GetComponent<Renderer>().material.color = new Color(1 - averageColor.b, 1 - averageColor.b, 1, averageColor.a);
		}
	}
		
}