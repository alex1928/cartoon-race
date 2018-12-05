using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassGenerator : MonoBehaviour {

	public List<GameObject> grassSpecies; 
	public int grassCount = 30;

	// Use this for initialization
	void Start () {
		
		GenerateGrass();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void RefreshGrass() {

		foreach(GameObject grass in GameObject.FindGameObjectsWithTag("Grass")) {

			Destroy(grass);
		}

		GenerateGrass();
	}

	private void GenerateGrass() {

		for(int i = 0; i < grassCount; i++) {

			Vector3 pos = GetRandomPointOnSurface();
			Quaternion rotation = Quaternion.Euler((float)Random.Range(0, 360), 0f, 0f);

			GameObject grass = Instantiate(grassSpecies[Random.Range(0, grassSpecies.Count-1)], pos, rotation);

			grass.transform.parent = transform;
		}
	}


	private Vector3 GetRandomPointOnSurface() {

		Vector3 min = GetComponent<MeshFilter>().sharedMesh.bounds.min;
		Vector3 max = GetComponent<MeshFilter>().sharedMesh.bounds.max;
		return transform.position -  new Vector3 ((Random.Range(min.x * transform.localScale.x, max.x * transform.localScale.x)), transform.position.y, (Random.Range(min.z*transform.localScale.z, max.z*transform.localScale.z)));
	}

	private Vector3 RandomPointOnPlane(Vector3 position, Vector3 normal, float radius)
    {
        Vector3 randomPoint;
 
        do
        {
            randomPoint = Vector3.Cross(Random.insideUnitSphere, normal);
        } while (randomPoint == Vector3.zero);
       
        randomPoint.Normalize();
        randomPoint *= radius;
        randomPoint += position;
       
        return randomPoint;
    }
}
