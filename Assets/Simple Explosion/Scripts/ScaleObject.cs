using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour {

	public Vector3 targetScale;
	public float time = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.localScale = Vector3.Lerp(Vector3.one, targetScale, time * Time.deltaTime);
	}
}
