using UnityEngine;
using System.Collections;

public class StartTouch : MonoBehaviour 
{
	void Update () 
	{
		if (Input.touchCount > 0) 
		{
			gameObject.GetComponent<Changement_de_scene>().LoadLevel1();
		}
	}
}
