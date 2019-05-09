using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Car {

	public float minSpeed = 3f;
	public float maxSpeed = 8f;

	public float frontMinDistanceToOtherCar = 5f;

	override public void Awake() {

		speed = Random.Range(minSpeed, maxSpeed);
		base.Awake();
	}


	void FixedUpdate()
    {
        SlowDownIfCarIsInFront();
    }

	private void OnTriggerEnter(Collider other) {

		Enemy enemy = other.GetComponent<Enemy>();

		if(enemy == null) {
			return;
		}

		targetVelocity.z = enemy.targetVelocity.z * 0.9f;
	}


	private void SlowDownIfCarIsInFront() {

		RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out hit, frontMinDistanceToOtherCar))
        {	
			Enemy enemyObject = hit.collider.GetComponent<Enemy>();

			if(enemyObject == null) {
				return;
			}

            targetVelocity = enemyObject.targetVelocity;
        }
	}
}
