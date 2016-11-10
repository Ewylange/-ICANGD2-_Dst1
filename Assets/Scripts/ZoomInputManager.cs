using UnityEngine;
using System.Collections;

public class ZoomInputManager : MonoBehaviour {
    
    [Range(0, 1)]
    public float zoomFactor = 0f;

    public float sensibility = 0.05f;

    float lastDist = -1;


    public CameraManager cameraManager;

    void Update () 
	{
	    if(Input.touchCount == 2) 
		{
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            float dist = Vector2.Distance(touch0.position, touch1.position);

            if(lastDist < 0) 
			{
                lastDist = dist;
                return;
            }

            float deltaDist = dist - lastDist;

            zoomFactor += deltaDist * sensibility * Time.deltaTime;
            zoomFactor = Mathf.Clamp(zoomFactor, 0, 1);

            cameraManager.zoomFactor = zoomFactor;
        } 
		else 
		{
            lastDist = -1;
        }
	}
}
