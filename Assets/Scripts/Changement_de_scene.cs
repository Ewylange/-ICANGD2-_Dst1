using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Changement_de_scene : MonoBehaviour 
{	
	void Update () 
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			SceneManager.LoadScene("Switch_scene2");
		}
	}

	public void LoadLevel(int level) 
	{
		SceneManager.LoadScene("Game");
	}

	public void ReloadLevel() 
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void BackToMainMenu() 
	{
		SceneManager.LoadScene("Menu");
	}
}
