using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameObject player;

	public float distance = 0f;

	public AudioClip music;


	void Awake() {

		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(player != null) {
		
			int playerDistance = (int)Mathf.Round(player.transform.position.z);
			UIManager.instance.UpdateDistanceText(playerDistance);
		}
	}



	public void GameOver() {

		EnemyManager.instance.StopSpawning();
		UIManager.instance.ShowGameOver();
	}

	public void GoToMenu() {

		SceneManager.LoadScene("Menu");
	}


	public void RestartGame() {

		SceneManager.LoadScene("Race");
	}


	public void ExitGame() {

		Application.Quit();
	}


	
}
