using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGeneration : MonoBehaviour {

	//Variables
	public GameObject[] obj;
	public Transform spawner;
	public float spawnMin = 0.1f;					//Randomly spawn between 1 and 2 seonds
	public float spawnMax = 1.0f;
	Vector3 previousPos;
	Vector3 offSet = new Vector3(8.23f, -3.36f, 0.0f);
	int count = 0;
	//public GameObject player;
	//float distance;

	// Use this for initialization
	void Start () 
	{
		Spawn ();																								//Calls Spawn function
	}
	
	// Update is called once per frame
	void Spawn () 
	{
		transform.position = spawner.position + count * offSet;													//Sets the position of the object 
		Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, obj[0].transform.rotation);		//Clones the original object and returns the clone
		Invoke("Spawn", Random.Range (spawnMin, spawnMax));														//Invokes the Methods methodname at the time set (between 1 and 2 seconds)
		count++;

	}
}
