using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour 
{
	Quaternion randomRotation = Random.rotation;

	void Start () 
	{
		transform.localRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
	}
	
	void Update () 
	{
        // Float animation
		const float speed = (2 * Mathf.PI) * 0.25f;
		const float amplitude = 0.5f;
        float integral = -(amplitude * Mathf.Cos(Time.time * speed)) / speed;

        transform.localPosition = transform.localPosition + transform.parent.forward * integral;
        // transform.localPosition = transform.localPosition + transform.parent.forward * -Mathf.Cos(Time.time * Mathf.Deg2Rad * 720f) * 0.1f;

        // Rotation animation
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, transform.localRotation * randomRotation, 45f * Time.deltaTime);
	}
}