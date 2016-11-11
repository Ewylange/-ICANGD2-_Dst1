using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour 
{
	public void ButtonPushHandler()
	{
		GameObject gameManager = GameObject.Find("GameManager");
		Changement_de_scene cds = gameManager.GetComponent<Changement_de_scene>();
		cds.LoadBegeningScene();
	}
}