using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class End : MonoBehaviour 
{
	private Image fade;

	void Start () 
	{
		fade = GameObject.Find("Fade").GetComponent<Image>();
		fade.color = new Color(0, 0, 0, 0);
	}
}