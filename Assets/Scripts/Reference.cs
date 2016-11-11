using UnityEngine;
using System.Collections;

public class Reference : MonoBehaviour 
{
	public Transform dad;
	public GameObject fuseCube;
	public AudioSource audioSource;
	public AudioClip success;

	GameObject newCube;

	public void Start()
	{
		audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
	}

	public void Fuse()
	{
		newCube = Instantiate(fuseCube);
		newCube.transform.SetParent(dad);
		newCube.transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
		newCube.transform.localScale = transform.localScale * 1.5f;
		audioSource.PlayOneShot(success);
		Destroy(gameObject);
	}
}
