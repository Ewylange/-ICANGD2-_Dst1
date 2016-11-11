using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Changement_de_scene : MonoBehaviour 
{	
	public string level1;
	public string level2;

	void Start () 
	{
        Scene scene = SceneManager.GetSceneByName(level2);
        if (!scene.isLoaded) {
            SceneManager.LoadScene(level2, LoadSceneMode.Additive);
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
