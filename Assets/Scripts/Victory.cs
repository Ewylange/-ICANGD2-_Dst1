using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour 
{
	public GameObject cube1;
	public GameObject cube2;
	public GameObject cube3;

	void Update () 
	{
		if(!cube1 && !cube2 && !cube3)
		{
			Debug.Log("Victory");
		}
	}
}
