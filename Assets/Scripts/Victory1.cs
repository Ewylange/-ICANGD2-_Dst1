using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Victory1 : MonoBehaviour 
{
	private AudioSource audioSource;
	public AudioClip victory;
	bool victoryStart = false;

	float t;
	private Image fade;
	private Changement_de_scene levelChanger;

	void Start () 
	{
		audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
		fade = GameObject.Find("Fade").GetComponent<Image>();
		levelChanger = GameObject.Find("GameManager").GetComponent<Changement_de_scene>();
	}

	void Update () 
	{
		if(!victoryStart)
		{
			fade.color = new Color(0, 0, 0, fade.color.a - (Time.deltaTime / 3));
		}
		else
		{
			t += Time.deltaTime;
			fade.color = new Color(0, 0, 0, (t/3) - 1);
			if(t > 4)
			{
				levelChanger.LoadEndScene();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag != "Player")
		{
			return;
		}
		if(!victoryStart)
		{
			audioSource.PlayOneShot(victory);
		}
		victoryStart = true;
	}
}
