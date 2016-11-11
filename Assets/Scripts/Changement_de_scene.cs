using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Changement_de_scene : MonoBehaviour 
{
//On mets en public le nom de chaque scène du jeu, ainsi que le nom de la scène de départ.
    [Header("Start Scene")]
    public string startScene;

    [Header("Scenes")]
    public string begeningScene;
    public string level1;
	public string level2;
    public string endScene;
    
	public System.Nullable<Scene> additionalLoadedScene = new System.Nullable<Scene>();

    void Start () 
	{
        LoadAdditionalScene(startScene);
    }

    public void LoadAdditionalScene(string additionalSceneName, bool unloadBeforeLoad = true) 
	{
        if (unloadBeforeLoad)
            UnloadCurrentlyLoadedAdditionalScene();
        Scene scene = SceneManager.GetSceneByName(additionalSceneName);
        if (!scene.isLoaded) 
		{
            SceneManager.LoadScene(additionalSceneName, LoadSceneMode.Additive);
        }
        additionalLoadedScene = scene;
    }

    public void UnloadCurrentlyLoadedAdditionalScene() {
        if (!additionalLoadedScene.HasValue)
            return;
		if(additionalLoadedScene.Value.isLoaded != true)
		{
			return;
		}
        SceneManager.UnloadScene(additionalLoadedScene.Value);
    }
		
    public void LoadBegeningScene() {
        LoadAdditionalScene(begeningScene);
    }
    public void LoadLevel1() {
        LoadAdditionalScene(level1);
    }
    public void LoadLevel2() {
        LoadAdditionalScene(level2);
    }
    public void LoadEndScene() {
        LoadAdditionalScene(endScene);
    }
}
