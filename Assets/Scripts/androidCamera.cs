using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class androidCamera : MonoBehaviour 
{
	float tempX;
	float tempY;
	//public GameObject dummy;
	//dummy.GetComponent<Text>().text += "at  " + transform.position + " zooming towards " + pos;
	public GameObject gameManager;

	public float startFOV = 70;
	public float maxFOV = 70;
	public float minFOV = 20;
	public float leftLimit;
	public float rightLimit;
	public float highLimit;
	public float lowLimit;
	private float fov;
	public bool rotating;

	void Start () 
	{
		fov = startFOV;
		Camera.main.orthographicSize = fov;
	}

	void Update () 
	{
////Horizontal et Vertical
//		if (Input.touchCount == 1 ) 
//		{
//			if (Input.GetTouch(0).phase == TouchPhase.Moved)
//			{
//				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//				float x = Mathf.Clamp(touchDeltaPosition.x * (fov), leftLimit, rightLimit);
//            	float y = Mathf.Clamp(touchDeltaPosition.y * (fov), lowLimit, highLimit);
//				Vector3 worldDelta = Camera.main.ScreenToWorldPoint(
//					new Vector3(
//						touchDeltaPosition.x,
//						touchDeltaPosition.y,
//						0
//					)
//				);
//            	transform.Translate( -touchDeltaPosition.x * (fov)/2 * Time.deltaTime, -touchDeltaPosition.y * (fov)/2 * Time.deltaTime, 0);
//			}
//        }
//Zoom et Dezoom

		if (Input.touchCount == 2)
        {
            // Store both touches.
        	Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - new Vector2(Screen.width, Screen.height) / 2;
			Vector2 touchOnePrevPos = touchOne.position - new Vector2(Screen.width, Screen.height) / 2;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Vector2 mPos = (touchZeroPrevPos - touchOnePrevPos)/2 + touchOnePrevPos;
            Vector3 middlePos =  Camera.main.ScreenToWorldPoint(mPos);

            if (deltaMagnitudeDiff < 0)
			{
				if(fov > minFOV)
				{
					zoomTowards(middlePos, -1);
				}
			}
			else if(deltaMagnitudeDiff > 0)
			{	
				if(fov < maxFOV)
				{
					zoomTowards(middlePos, 1);
				}
			}  
		}
	}

	void zoomTowards(Vector3 pos, float direction)
	{
		Camera.main.orthographicSize += direction*10;
		fov += direction * 10;
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minFOV, maxFOV);			
		float multiplier = (10f / Camera.main.orthographicSize);
		if(pos.x < leftLimit) pos.x = leftLimit;
		else if(pos.x > rightLimit) pos.x = rightLimit;
		if(pos.y < lowLimit) pos.y = lowLimit;
		else if(pos.y > highLimit) pos.y = highLimit;
		transform.position += (pos - transform.position) * multiplier;
	}
}