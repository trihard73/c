using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 120f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 80.0f;
	public float inputSensitivity = 150f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistaneXToPlayer;
	public float camDistaneYToPlayer;
	public float camDistaneZToPlayer;
	public float mouseX;
	public float mouseY;
	public float finalinputX;
	public float finalinputZ;
	public float smoothX;
	public float smoothY;

	private float rotY = 0.0f;
	private float rotX = 0.0f;

	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update () {
		float inputX = Input.GetAxis ("RightStickHorizontal");
		float inputZ = Input.GetAxis ("RightStickVertical");
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
		finalinputX = inputX + mouseX;
		finalinputZ = inputZ - mouseY;

		rotY += finalinputX * inputSensitivity * Time.deltaTime;
		rotX += finalinputZ * inputSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0f);
		transform.rotation = localRotation;
	}

	void LateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater () {
		Transform target = CameraFollowObj.transform;

		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}
