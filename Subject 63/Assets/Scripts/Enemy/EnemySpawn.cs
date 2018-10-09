using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject cylinder;
    public Transform Plane;
    // Use this for initialization
    void Start () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        print("hi!");
        Instantiate(cylinder, Plane.position, Plane.rotation);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
