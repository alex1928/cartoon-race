using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Car : MonoBehaviour {

	public float speed = 10f;

	public float acceleration = 4f;

	public float horizontalSpeed = 5f;
	public float horizontalAcceleration = 10f;

	protected Vector3 targetVelocity;

	private Vector3 currentVelocity = Vector3.zero;

	public GameObject explosionEffect;
	public bool destroyed = false;


	public virtual void Awake() {

		targetVelocity = new Vector3(0f, 0f, speed);
	}
	
	// Update is called once per frame
	public void Update () {

		MoveCar();
	}

	public float GetSpeed() {

		return currentVelocity.z;
	}

	private void MoveCar() {

		if(destroyed) {

			targetVelocity.z = 0f;
			targetVelocity.x = 0f;
		}

		currentVelocity.z = Mathf.Lerp(currentVelocity.z, targetVelocity.z, Time.deltaTime * acceleration);
		currentVelocity.x = Mathf.Lerp(currentVelocity.x, targetVelocity.x, Time.deltaTime * horizontalAcceleration);
		transform.position += currentVelocity * Time.deltaTime;

		transform.rotation = Quaternion.Euler(0, -180f + currentVelocity.x * 4f, 0);
	}


	public void Explode() {

		explosionEffect.transform.parent = transform.parent;
		explosionEffect.transform.position = transform.position;
		explosionEffect.SetActive(true);
		gameObject.SetActive(false);
		destroyed = true;
	}
}
