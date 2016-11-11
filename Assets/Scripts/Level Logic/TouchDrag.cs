using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TouchDrag : MonoBehaviour 
{
	private float dist;
	private bool dragging = false;
	private Vector3 offset;
	private Transform toDrag;

	public AudioSource audioSource;
	public AudioClip select;

    public Camera dragCamera;

    private Vector3 startDragPosition;

    public void Awake() {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    public void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        GameObject cubeCamera = GameObject.Find("CubeCamera");
        if (cubeCamera == null)
            return;
        dragCamera = GameObject.Find("CubeCamera").GetComponent<Camera>();
    }

	void Update5() 
	{
        if (dragCamera == null)
            return;

		Vector3 v3;
		if (Input.touchCount != 1) 
		{
			dragging = false; 
			return;
		}

		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;

		if(touch.phase == TouchPhase.Began) 
		{
			RaycastHit hit;
			Ray ray = dragCamera.ScreenPointToRay(pos); 
			if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
			{
				audioSource.PlayOneShot(select);
				toDrag = hit.transform;
				dist = hit.transform.position.z - dragCamera.transform.position.z;
				v3 = new Vector3(pos.x, pos.y, dist);
				v3 = dragCamera.ScreenToWorldPoint(v3);
				offset = toDrag.position - v3;
				dragging = true;
			}
		}
		if (dragging && touch.phase == TouchPhase.Moved) 
		{
			v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
			v3 = dragCamera.ScreenToWorldPoint(v3);
			toDrag.position = v3 + offset;
		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) 
		{
			dragging = false;
			toDrag.gameObject.GetComponent<ColorChannel>().EndDrag();
		}
    }

    void Update2() {
        if (dragCamera == null)
            return;

        Vector3 v3;
        if (Input.touchCount != 1) {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Ray ray = dragCamera.ScreenPointToRay(pos);
            LayerMask mask = LayerMask.GetMask("Flying Cube Debug");
            if (Physics.Raycast(ray, out hit, maxDistance: 15f, layerMask: mask) && (hit.collider.tag == "Draggable")) {
                audioSource.PlayOneShot(select);
                toDrag = hit.transform;
                dist = hit.transform.localPosition.z - dragCamera.transform.localPosition.z;
                v3 = new Vector3(pos.x, pos.y, dist);
                startDragPosition = v3;
                v3 = dragCamera.ScreenToWorldPoint(v3);
                offset = toDrag.localPosition - v3;
                dragging = true;
            }
        }
        if (dragging && touch.phase == TouchPhase.Moved) {
            v3 = new Vector3(pos.x, pos.y, dist);
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = dragCamera.ScreenToWorldPoint(v3);


            toDrag.localPosition = v3 + offset;
        }
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
            dragging = false;
            toDrag.gameObject.GetComponent<ColorChannel>().EndDrag();
        }
    }

    void Update() {
        if (dragCamera == null)
            return;
        
        if (Input.touchCount != 1) {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 touchPos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Ray ray = dragCamera.ScreenPointToRay(touchPos);
            LayerMask mask = LayerMask.GetMask("Flying Cube Debug");
            if (Physics.Raycast(ray, out hit, maxDistance: 15f, layerMask: mask) && (hit.collider.tag == "Draggable")) {
                // Audio feedback
                audioSource.PlayOneShot(select);
                // Retrive the transform selected for this drag
                toDrag = hit.transform;
                // Get the distance from camera
                dist = hit.transform.localPosition.z;
                // Set dragging flag
                dragging = true;
            }
        }
        if (dragging && touch.phase == TouchPhase.Moved) {
            touchPos.z = dist;
            Vector3 targetPos = dragCamera.ScreenToWorldPoint(touchPos);            
            toDrag.position = targetPos;
        }
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
            dragging = false;
            toDrag.gameObject.GetComponent<ColorChannel>().EndDrag();
        }
    }
}