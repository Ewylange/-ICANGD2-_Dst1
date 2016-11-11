using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transparent : MonoBehaviour
{
	Image image;

	void Start() 
	{
		image = GetComponent<Image>();
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.6f);
	}
}