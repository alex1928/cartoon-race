using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	private Player player;
	private Camera camera;
	public float delay = 4f;

	public float slowCameraFliedOfView = 50f;
	public float fastCameraFieldOfView = 60f;

	void Awake() {

		camera = GetComponentInChildren<Camera>();
		player = target.transform.GetComponent<Player>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float nCameraVal = Mathf.InverseLerp(player.slowSpeed, player.fastSpeed, player.GetSpeed());
	    camera.fieldOfView = Mathf.Lerp(slowCameraFliedOfView, fastCameraFieldOfView, nCameraVal);

		Vector3 movedTarget = target.transform.position + new Vector3(0f, 0f, 5f);

		transform.position = Vector3.Lerp(transform.position, movedTarget, delay * Time.deltaTime);
	}
}
