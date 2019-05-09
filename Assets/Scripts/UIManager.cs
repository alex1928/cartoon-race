using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text distanceText;

	public GameObject gameOverPanel;

	public GameObject joystickObject;

	public Text finalScore;

	public FixedJoystick joystick;

	public bool isMobile = false;

	void Awake() {

		instance = this;
	}


	// Use this for initialization
	void Start () {

		joystick = joystickObject.GetComponent<FixedJoystick>();

		isMobile = Application.platform == RuntimePlatform.IPhonePlayer;
		joystickObject.SetActive(isMobile);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void UpdateDistanceText(int distance) {

		distanceText.text = "Distance: " + distance + "m";
	}

	public void ShowGameOver() {

		finalScore.text = GameManager.instance.distance.ToString();
		gameOverPanel.SetActive(true);
	}
}
