using UnityEngine;
using System.Collections;

public class StartTouch : MonoBehaviour 
{
	GameObject gameManager;

	void Start () 
	{
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
