using UnityEngine;
using System.Collections;

public class Level2Manager : MonoBehaviour 
{
	public GameObject cubeLock;
	public GameObject cubeCam;

	void Start () 
	{
		GameObject targetCam = GameObject.Find("Camera");

		cubeLock.transform.SetParent(targetCam.transform);
		cubeLock.transform.localPosition = Vector3.zero;
		cubeLock.transform.localRotation = Quaternion.identity;
		cubeLock.transform.localScale = Vector3.one;


		cubeCam.transform.SetParent(targetCam.transform);
		cubeCam.transform.localPosition = Vector3.zero;
		cubeCam.transform.localRotation = Quaternion.identity;
		cubeCam.transform.localScale = Vector3.one;
	}
}
