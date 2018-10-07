﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollsion : MonoBehaviour {

	public float minDistance = 1f;
	public float maxDistance = 2f;
	public float smooth = 10f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;

	void Awake () {
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}

	void Update () {
		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
		RaycastHit hit;

		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
			distance = Mathf.Clamp ((hit.distance * 0.9f), minDistance, maxDistance);
		} else {
			distance = maxDistance;
		}

		transform.localPosition = Vector3.Lerp (transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
