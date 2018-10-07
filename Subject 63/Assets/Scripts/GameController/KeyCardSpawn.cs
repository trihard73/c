using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardSpawn : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject keyCard;

	void Start () {
		Spawn ();
	}

	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (keyCard, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
