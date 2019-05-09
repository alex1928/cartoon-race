using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public static EnemyManager instance;

	public List<GameObject> enemyPrefabs = new List<GameObject>();

	public float[] spawnPoints = {-3.3f, 0f, 3.3f};
	public float spawnInterval = 5f;
	public int minSpawnCount = 1;
	public int maxSpawnCount = 5;

	public GameObject player;

	public float spawnDistanceFromPlayer = 30f;
	private float spawnCounter = 0f;

	public bool shouldSpawnEnemies = true;

	[SerializeField]
	private List<GameObject> spawnedEnemies = new List<GameObject>();
	
	void Awake() {

		instance = this;
	}

	// Use this for initialization
	void Start () {
		
		spawnCounter = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {

		spawnCounter -= Time.deltaTime;

		if(spawnCounter <= 0f && shouldSpawnEnemies) {

			SpawnEnemies();
			spawnCounter = spawnInterval;
		}

		RemoveEnemies();
	}

	public void StopSpawning() {

		shouldSpawnEnemies = false;
	}

	public void SpawnEnemies() {

		float distanceFromPrevious = spawnDistanceFromPlayer + (float)Random.Range(0, 5);

		int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);


		for(int i = 0; i < spawnCount; i++) {

			Vector3 position = new Vector3(spawnPoints[Random.Range(0, spawnPoints.Length - 1)], 
										   0f, 
										   player.transform.position.z + distanceFromPrevious + i * 5f);
										   
			SpawnEnemy(position);
		}
	}

	public void SpawnEnemy(Vector3 position) {

		if(enemyPrefabs.Count == 0) {

			return;
		}

		GameObject randPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count - 1)];

		GameObject spawnedEnemy = Instantiate(randPrefab, position, randPrefab.transform.rotation);

		spawnedEnemies.Add(spawnedEnemy);
	}

	public void RemoveEnemies() {

		if(spawnedEnemies.Count == 0) {

			return;
		}

		GameObject enemy = spawnedEnemies[0];
		
		if(enemy.transform.position.z < player.transform.position.z && Vector3.Distance(enemy.transform.position, player.transform.position) > spawnDistanceFromPlayer * 1.5) {

			RemoveEnemy(enemy);
		}
	}


	public void RemoveEnemy(GameObject enemy, float time = 0f) {

		spawnedEnemies.Remove(enemy);
		Destroy(enemy, time);
	}
}
