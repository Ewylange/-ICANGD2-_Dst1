using UnityEngine;
using System.Collections;

public class ZoomDoubleInput : MonoBehaviour 
{
	Vector3 camForward;
	Vector3 camStart;

	public float zoomDistance;
	float timeSinceTouch = 0.5f;

	bool forward;
	bool backward;

	void Start () 
	{
		camStart =  transform.position;
	}

	void Update () 
	{
		camForward = camStart + (transform.forward * 8);

		timeSinceTouch += Time.deltaTime;

		if(Input.touchCount > 0)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				if(timeSinceTouch < 0.5f)
				{
					if(Vector3.Distance(transform.position, camStart) < 0.1f)
					{
						forward = true;
					}
					if(Vector3.Distance(transform.position, camForward) < 0.1f)
					{
						backward = true;
					}
				}
				timeSinceTouch = 0;
			}
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
