using UnityEngine;
using System.Collections;

public class Changement_de_scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow))
			{
	
			Application.LoadLevel("Switch_scene2");
		}
	}
}
