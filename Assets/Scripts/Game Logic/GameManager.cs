using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	void Awake() {
        // Configure device
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		QualitySettings.vSyncCount = 0;  
		Application.targetFrameRate = 45;
	}

    public GameObject level1prefab;
    public GameObject level2prefab;
}
