using UnityEngine;
using System.Collections;

public class Changement_de_scene : MonoBehaviour {


	// Update is called once per frame
	void Update () {
//
//		if (Input.GetKey(KeyCode.UpArrow))
//			{
//	
//			Application.LoadLevel("Switch_scene2");
//		}

	}

	public void LoadLevel(int level) {
		
		Application.LoadLevel("Game");
	}

	// Quit the game
	public void QuitGame() {
		Application.Quit();
	}

	// Reload this level

//	public void ReloadLevel() 
//	{
//		Scene scene = SceneManager.GetActiveScene();
//		SceneManager.LoadScene(scene.name);
////		Application.LoadLevel(Application.loadedLevel);
//	}

	public void ReloadLevel() {
		Application.LoadLevel(Application.loadedLevel);

	}

	// Go back to main menu
	public void BackToMainMenu() {
		Application.LoadLevel("Menu");
	}
}
