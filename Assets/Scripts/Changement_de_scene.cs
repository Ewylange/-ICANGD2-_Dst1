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

    public string currentlyLoadedScene;

    void Start () {
        LoadAdditionalScene(startScene, false);
    }

    public void LoadAdditionalScene(string additionalSceneName, bool unloadBeforeLoad = true) {
        // Unload before load if necesary
        if (unloadBeforeLoad)
            UnloadCurrentlyLoadedAdditionalScene();

        // Check if scene is already loaded
        if (currentlyLoadedScene == additionalSceneName) {
            // Scene already loaded
            return;
        }

        // Load scene
        SceneManager.LoadScene(additionalSceneName, LoadSceneMode.Additive);
        // Remember currently loaded scene
        currentlyLoadedScene = additionalSceneName;
    }

    public void UnloadCurrentlyLoadedAdditionalScene() {
        // Check if there is a currently loaded scene to unload
        if (string.IsNullOrEmpty(currentlyLoadedScene)) {
            return;
        }
        // Unload if it can
        SceneManager.UnloadScene(currentlyLoadedScene);

        if(currentlyLoadedScene == level2) {
            // Debug : clear camera child
            GameObject camera = GameObject.Find("Camera");
            for (int i = camera.transform.childCount - 1; i >= 0; --i) {
                Destroy(camera.transform.GetChild(i).gameObject);
            }
        }
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
