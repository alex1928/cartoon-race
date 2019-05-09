using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Car {

	public float slowSpeed = 5f;
	public float fastSpeed = 15f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {

		base.Update();

		float speedAxis = GetSpeedAxis();
		float directionAxis = GetDirectionAxis();

		if(transform.position.x <= -3.9 && directionAxis < 0) {
			directionAxis = 0f;
		}

		if(transform.position.x >= 3.9 && directionAxis > 0) {
			directionAxis = 0f;
		}

		if(speedAxis > 0.1) {
			targetVelocity.z = fastSpeed;
		} else if(speedAxis < -0.1) {
			targetVelocity.z = slowSpeed;
		} else {
			targetVelocity.z = speed;
		}

		targetVelocity.x = horizontalSpeed * directionAxis;
	}


	private float GetSpeedAxis() {

		if(Application.platform == RuntimePlatform.IPhonePlayer) {

			return UIManager.instance.joystick.Vertical;
		}

		return Input.GetAxis("Vertical");
	}

	private float GetDirectionAxis() {

		if(Application.platform == RuntimePlatform.IPhonePlayer) {

			return UIManager.instance.joystick.Horizontal;
		}
		
		return Input.GetAxis("Horizontal");
	}

	
	void OnTriggerEnter(Collider other)
	{	
		other.GetComponent<Enemy>().Explode();
		EnemyManager.instance.RemoveEnemy(other.transform.gameObject, 1f);

		Explode();

		GameManager.instance.GameOver();
	}

}
