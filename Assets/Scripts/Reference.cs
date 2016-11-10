using UnityEngine;
using System.Collections;

public class Reference : MonoBehaviour 
{
	public GameObject fuseCube;

	public void Fuse()
	{
		Instantiate(fuseCube);
		Destroy(gameObject);
	}
}
