using UnityEngine;
using System.Collections;

public class ZoomDoubleInput : MonoBehaviour 
{
	Vector3 camForward;
	Vector3 camStart;

	public float zoomDistance;
	float acumTime;

	bool forward;
	bool backward;

	void Start () 
	{
		camStart =  transform.position;
	}

	void Update () 
	{
		camForward = camStart + (transform.forward * 8);

		if(Input.touchCount == 2)
		{
			if(Vector3.Distance(transform.position, camStart) < 0.1f)
			{
				forward = true;
			}
			if(Vector3.Distance(transform.position, camStart) < 0.1f)
			{
				forward = true;
			}
		}

		if(Input.GetKeyDown(KeyCode.Z))
		{
			forward = true;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			backward = true;
		}


		if(forward)
		{
			Forward();
		}
		else if(backward)
		{
			BackWard();
		}
	}

	void Forward()
	{
		if(Vector3.Distance(transform.position, camForward) < 0.1f)
		{
			forward = false;
			return;
		}
		transform.position = Vector3.Lerp(transform.position, camForward, 0.2f);
	}

	void BackWard()
	{
		if(Vector3.Distance(transform.position, camStart) < 0.1f)
		{
			backward = false;
			return;
		}
		transform.position = Vector3.Lerp(transform.position, camStart, 0.2f);
	}
}
