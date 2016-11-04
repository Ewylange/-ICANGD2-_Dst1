using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour 
{
	public int touchCount = 0;
	public Text textX;
	public Text textY;

	void Update () 
	{
		if(Input.touchCount < touchCount + 1) 
		{
			transform.localPosition = new Vector3(-1000, -1000, 0);
			return;
		}
		Touch touch = Input.GetTouch(touchCount);
		transform.localPosition = touch.position - new Vector2(Screen.width, Screen.height) / 2;
		textX.text = touch.position.x.ToString();
		textY.text = touch.position.y.ToString();
	}
}
