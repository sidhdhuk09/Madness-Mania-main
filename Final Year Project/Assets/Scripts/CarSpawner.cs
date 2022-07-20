using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
	//Declaring positions
	public Transform[] positions;
	//object as a reference at positions above
	public GameObject objPrefab;

	public bool spawn = true;
	//The speed of spawining objects
	public int spawnRate = 5;

	public int spawnDelay = 3;


	private Transform spawnLocation;
	private List<GameObject> spawnedObjects;

	private void Start()
	{
		spawnedObjects = new List<GameObject>();
		//Using coroutine for next spawn
		StartCoroutine(SpawnCaller());
		//InvokeRepeating(nameof(SpawnObject), spawnDelay, spawnRate);
	}


	IEnumerator SpawnCaller()
	{
		//Waiting for next spawn 
		yield return new WaitForSeconds(spawnDelay);
		WaitForSeconds spawnRateSeconds = new WaitForSeconds(spawnRate);
		while (spawn)
		{
			//calling function here
			SpawnObject();
			yield return spawnRateSeconds;
		}
	}

	private void SpawnObject()
	{
		// remove deleted collotables from the list
		for (int i = spawnedObjects.Count - 1; i >= 0; i--)
		{
			if (spawnedObjects[i] == null)
			{
				spawnedObjects.RemoveAt(i);
			}
		}
		// choose new position to instantiate the object
		spawnLocation = positions[Random.Range(0, positions.Length)];
		// if "checkForCollision" is true, make sure no already existing object that we instantiated is in the same position

		//Instantiating at spawn positions
		GameObject spawnedObj = Instantiate(objPrefab, spawnLocation.position, spawnLocation.rotation, transform);
		spawnedObjects.Add(spawnedObj);
	}
}