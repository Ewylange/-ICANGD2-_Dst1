using UnityEngine;
using System.Collections;

public class ZoomDoubleInput : MonoBehaviour 
{
	
	public float zoomDistance;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 

	{

//			if(Input.touchCount == 2) {
//				Touch touch0 = Input.GetTouch(0);
//				Touch touch1 = Input.GetTouch(1);

		Vector3 camZoom =  new Vector3(transform.position.x,transform.position.y, transform.position.z + zoomDistance);
		Vector3 camDeZoom =  new Vector3(transform.position.x,transform.position.y, transform.position.z - zoomDistance);

	

		if(Input.GetKeyUp(KeyCode.D))
		{
			
			//this.transform.Translate(Vector3.Lerp( transform.position , this.transform.position + Vector3.back , 0.4f));
			//transform.position += new Vector3 ( 0,0, -zoomDistance);
			transform.position = Vector3.Lerp(transform.position, camDeZoom, 1f);

		}

		if(Input.GetKeyUp(KeyCode.Z))
		{

			//transform.position += new Vector3 ( 0,0, zoomDistance);
			transform.position = Vector3.Lerp(transform.position, camZoom, 1f);
			//transform.position.z += Mathf.Lerp
			//this.transform.Translate(Vector3.Lerp( transform.position , -this.transform.position + Vector3.back * 0.7f, 0.7f));
		}

	}
}
