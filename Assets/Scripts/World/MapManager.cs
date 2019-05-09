using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> mapParts = new List<GameObject>();
	public GameObject lastMapPart;
	public GameObject player;
	public float spawnOffset = 42.7f;

	public int startMapElementsCount = 2;

	//private List<GameObject> spawnedMapParts = new List<GameObject>();

	private Queue<GameObject> spawnedMapParts = new Queue<GameObject>();


	void Start () {
		
		if(lastMapPart != null) {
			spawnedMapParts.Enqueue(lastMapPart);
		}
		
		GenerateStartMap();
	}
	
	// Update is called once per frame
	void Update () {

		if(lastMapPart == null)
			return;		

		if(Vector3.Distance(player.transform.position, lastMapPart.transform.position) < spawnOffset) {

			RespawnOldMapPart();
		}
	}

	void GenerateStartMap() {

		for(int i = 0; i < startMapElementsCount; i++) {

			Vector3 position = GetNextMapPosition();
			
			GameObject randomPrefab = mapParts[Random.Range(0, mapParts.Count - 1)];
			
			lastMapPart = Instantiate(randomPrefab, position, Quaternion.identity);
			spawnedMapParts.Enqueue(lastMapPart);
		}
	}

	

	void RespawnOldMapPart() {

		if(spawnedMapParts.Count == 0) {
			return;
		}
	
		GameObject mapToRespawn = spawnedMapParts.Dequeue();

		mapToRespawn.transform.position = GetNextMapPosition();
		lastMapPart = mapToRespawn;
		spawnedMapParts.Enqueue(mapToRespawn);
	}

	Vector3 GetNextMapPosition() {

		return lastMapPart.transform.position + new Vector3(0f, 0f, spawnOffset);
	}
}
