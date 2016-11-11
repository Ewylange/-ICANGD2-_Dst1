using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour 
{
	Quaternion randomRotation = Random.rotation;
	Vector3 startPosition;

	void Start () 
	{
		transform.localRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
	}
	
	void Update () 
	{
		float speed = Mathf.PI/2;
		float amplitude = 0.5f;

//		transform.localPosition = transform.localPosition + transform.parent.forward * -Mathf.Cos(Time.time * Mathf.Deg2Rad * 720f) * 0.1f;

		transform.localPosition = transform.localPosition + transform.parent.forward * (-(amplitude * Mathf.Cos(Time.time * speed))/speed);


		transform.localRotation = Quaternion.RotateTowards(transform.localRotation, transform.localRotation * randomRotation, 45f * Time.deltaTime);
	}
}