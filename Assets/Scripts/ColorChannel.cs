using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorChannel : MonoBehaviour 
{
	public WebCam webCam;
	Color averageColor;

	public string colorChannel;
	public Transform referenceCube;
	float referenceWhite;
	bool matching;

	Vector3 initialPosition;

	void Start()
	{
		initialPosition = transform.localPosition;
		if(colorChannel == "Red")
		{
			referenceWhite = referenceCube.GetComponent<Renderer>().material.color.b;
		}
		else if(colorChannel == "Green")
		{
			referenceWhite = referenceCube.GetComponent<Renderer>().material.color.r;
		}
		else if(colorChannel == "Blue")
		{
			referenceWhite = referenceCube.GetComponent<Renderer>().material.color.g;
		}
	}

	void Update() 
	{
		averageColor = webCam.averageColor;

		if(colorChannel == "Red")
		{
			GetComponent<Renderer>().material.color = new Color(1, 1 - averageColor.r, 1 - averageColor.r, averageColor.a);
			if(Mathf.Abs((1 - averageColor.r) - referenceWhite) < 0.1f)
			{
				matching = true;
			}
			else
			{
				matching = false;
			}
		}
			
		else if(colorChannel == "Green")
		{
			GetComponent<Renderer>().material.color = new Color(1 - averageColor.g, 1, 1 - averageColor.g, averageColor.a);
			if(Mathf.Abs((1 - averageColor.g) - referenceWhite) < 0.1f)
			{
				matching = true;
			}
			else
			{
				matching = false;
			}
		}

		else if(colorChannel == "Blue")
		{
			GetComponent<Renderer>().material.color = new Color(1 - averageColor.b, 1 - averageColor.b, 1, averageColor.a);
			if(Mathf.Abs((1 - averageColor.b) - referenceWhite) < 0.1f)
			{
				matching = true;
			}
			else
			{
				matching = false;
			}
		}

		if(Input.GetKey(KeyCode.Space))
		{
			Destroy(gameObject);
			referenceCube.GetComponent<Reference>().Fuse();
		}
	}

	public void EndDrag()
	{
		if(Vector3.Distance(transform.position, referenceCube.position) < 0.3f && matching)
		{
			Destroy(gameObject);
			referenceCube.GetComponent<Reference>().Fuse();
		}
		else
		{
			transform.localPosition = initialPosition;
		}
	}
}