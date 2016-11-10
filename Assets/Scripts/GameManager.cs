using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	void Awake() 
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		QualitySettings.vSyncCount = 0;  
		Application.targetFrameRate = 45;
	}
}
