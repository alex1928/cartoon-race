using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Car {

	public float minSpeed = 3f;
	public float maxSpeed = 8f;

	override public void Awake() {

		speed = Random.Range(minSpeed, maxSpeed);
		base.Awake();
	}

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		base.Update();

		
	}

	void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            Debug.Log("There is something in front of the object!");
    }

	private void OnTriggerEnter(Collider other) {

		Enemy enemy = other.GetComponent<Enemy>();

		if(enemy == null) {
			return;
		}

		targetVelocity.z = enemy.targetVelocity.z * 0.9f;
	}
}
