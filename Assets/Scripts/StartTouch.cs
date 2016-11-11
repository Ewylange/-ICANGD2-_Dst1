using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTouch : MonoBehaviour 
{
	GameObject gameManager;
	private Image fade;

	void Start () 
	{
		fade = GameObject.Find("Fade").GetComponent<Image>();
		fade.color = new Color(0, 0, 0, 0);
		gameManager = GameObject.Find("GameManager");
	}

	void Update () 
	{
		if (Input.touchCount > 0) 
		{
			gameManager.GetComponent<Changement_de_scene>().LoadLevel1();
		}
	}
}
