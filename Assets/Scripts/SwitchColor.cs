using UnityEngine;
using System.Collections;

public class SwitchColor : MonoBehaviour {

	public Material colorCube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//this.gameObject.GetComponent<Material>().color = colorCube;
		this.gameObject.GetComponent<Renderer>().material= colorCube;
	}
}
