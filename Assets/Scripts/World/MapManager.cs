using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> mapParts = new List<GameObject>();
	public GameObject lastMapPart;
	public GameObject player;
	public float spawnOffset = 42.7f;

	private List<GameObject> spawnedMapParts = new List<GameObject>();


	void Start () {
		
		spawnedMapParts.Add(lastMapPart);
		GenerateMapPart();
	}
	
	// Update is called once per frame
	void Update () {
		
		RemoveOldMapPart();

		if(Vector3.Distance(player.transform.position, lastMapPart.transform.position) < spawnOffset) {

			GenerateMapPart();
		}
	}


	void GenerateMapPart() {

		Vector3 position = lastMapPart.transform.position + new Vector3(0f, 0f, spawnOffset);
		
		GameObject randomPrefab = mapParts[Random.Range(0, mapParts.Count - 1)];
		
		lastMapPart = Instantiate(randomPrefab, position, Quaternion.identity);
		spawnedMapParts.Add(lastMapPart);
	}

	void RemoveOldMapPart() {

		if(spawnedMapParts.Count == 0) {
			return;
		}

		GameObject mapToRemove = spawnedMapParts[0];

		if(Vector3.Distance(player.transform.position, mapToRemove.transform.position) > spawnOffset) {

			spawnedMapParts.Remove(mapToRemove);
			Destroy(mapToRemove);
		}
	}
}
