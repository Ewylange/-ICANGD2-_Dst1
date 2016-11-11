using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Victory2 : MonoBehaviour 
{
	public GameObject cube1;
	public GameObject cube2;
	public GameObject cube3;

	public AudioSource audioSource;
	public AudioClip victory;
	bool victoryStart = false;

	float t;
	public Image fade; 


	void Update () 
	{
		if(!cube1 && !cube2 && !cube3)
		{
			if(!victoryStart)
			{
				audioSource.PlayOneShot(victory);
				victoryStart = true;
			}
			t += Time.deltaTime;
			fade.color = new Color(0, 0, 0, (t/3) - 1);
		}
		else
		{
			fade.color = new Color(0, 0, 0, fade.color.a - (Time.deltaTime / 3));
		}
	}
}
