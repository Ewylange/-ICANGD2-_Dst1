using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour 
{
	float rotationX;
	float rotationY;

	Vector3 startPosition;
	Vector3 highPosition;
	Vector3 lowPosition;

//	Vector3 startRotation;
//	Vector3 UpRotation;
//	Vector3 DownRotation;
//	Vector3 RightRotation;
//	Vector3 LeftRotation;

	bool moveUp;
	bool lookUp;
	bool lookRight;

	void Awake () 
	{
		startPosition = transform.localPosition;
		highPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.25f, transform.localPosition.z);
		lowPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.25f, transform.localPosition.z);

//		startRotation = transform.localRotation.eulerAngles;
//		UpRotation = new Vector3(transform.localEulerAngles.x + 15, transform.localEulerAngles.y, transform.localEulerAngles.z);
//		DownRotation = new Vector3(transform.localEulerAngles.x - 15, transform.localEulerAngles.y, transform.localEulerAngles.z);
//		RightRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 15, transform.localEulerAngles.z);
//		LeftRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 15, transform.localEulerAngles.z);
//
		moveUp = Random.value >= 0.5f;
		lookUp = Random.value >= 0.5f;
		lookRight = Random.value >= 0.5f;
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Random.Range(-0.25f, 0.25f), transform.localPosition.z);
		transform.localRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), transform.localRotation.z);

		rotationX = transform.localEulerAngles.x;
		rotationY = transform.localEulerAngles.y;
	}
	
	void Update () 
	{
		if(moveUp)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, highPosition, 0.01f - (Mathf.Abs(transform.localPosition.y - startPosition.y) * 0.03f));
			if(Mathf.Abs(transform.localPosition.y - highPosition.y) < 0.01f)
			{
				moveUp = !moveUp;
			}
		}
		else
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, lowPosition, 0.01f - (Mathf.Abs(transform.localPosition.y - startPosition.y) * 0.03f));
			if(Mathf.Abs(transform.localPosition.y - lowPosition.y) < 0.01f)
			{
				moveUp = !moveUp;
			}
		}

		if(lookUp)
		{
			rotationX = Mathf.MoveTowards(rotationX, rotationX + 180, 0.5f);
//			rotationX = Mathf.MoveTowards(rotationX, UpRotation.x, 0.5f - Mathf.Clamp01((Mathf.Abs(rotationX - startRotation.x) * 0.02f)));
//			if(Mathf.Abs(rotationX - UpRotation.x) < 0.1f)
//			{
//				lookUp = !lookUp;
//			}
		}
		else
		{
			rotationX = Mathf.MoveTowards(rotationX, rotationX + 180, -0.5f);
//			rotationX = Mathf.MoveTowards(rotationX, DownRotation.x, 0.5f - Mathf.Clamp01((Mathf.Abs(rotationX - startRotation.x) * 0.02f)));
//			if(Mathf.Abs(rotationX - DownRotation.x) < 0.1f)
//			{
//				lookUp = !lookUp;
//			}
		}
		if(lookRight)
		{
			rotationY = Mathf.MoveTowards(rotationY, rotationY + 180, 0.5f);
//			rotationY = Mathf.MoveTowards(rotationY, RightRotation.y, 0.5f - Mathf.Clamp01((Mathf.Abs(rotationY - startRotation.y) * 0.02f)));
//			if(Mathf.Abs(rotationY - RightRotation.y) < 0.1f)
//			{
//				lookRight = !lookRight;
//			}
		}
		else
		{
			rotationY = Mathf.MoveTowards(rotationY, rotationY + 180, -0.5f);
//			rotationY = Mathf.MoveTowards(rotationY, LeftRotation.y, 0.5f - Mathf.Clamp01((Mathf.Abs(rotationY - startRotation.y) * 0.02f)));
//			if(Mathf.Abs(rotationY - LeftRotation.y) < 0.1f)
//			{
//				lookRight = !lookRight;
//			}
		}

		transform.localRotation = Quaternion.Euler(rotationX, rotationY, transform.localRotation.z);
	}
}
