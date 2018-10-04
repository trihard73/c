using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

	public float deadZone = 5f;
	public Animator anim;

	private Transform player;
	private EnemySight enemySight;
	private UnityEngine.AI.NavMeshAgent nav;
	//private Animator anim;
	private HashIDs hash;
	private AnimatorSetup animSetUp;

	void Awake () {
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		//anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();

		nav.updateRotation = false;
		animSetUp = new AnimatorSetup (anim, hash);

		anim.SetLayerWeight (1, 1f);
		anim.SetLayerWeight (2, 1f);

		deadZone *= Mathf.Deg2Rad;
	}

	void Update () {
		NavAnimSetup ();
	}

	void OnAnimatorMove () {
		nav.velocity = anim.deltaPosition / Time.deltaTime;
		anim.transform.rotation = anim.rootRotation;
	}

	void NavAnimSetup () {
		float speed;
		float angle;

		if (enemySight.playerInSight) {
			speed = 0f;
			angle = FindAngle (anim.transform.forward, player.position - transform.position, transform.up);
		} else {
			speed = Vector3.Project (nav.desiredVelocity, anim.transform.forward).magnitude;
			angle = FindAngle (anim.transform.forward, nav.desiredVelocity, transform.up);

			if (Mathf.Abs (angle) < deadZone) {
				anim.transform.LookAt (transform.position + nav.desiredVelocity);
				angle = 0f;
			}
		}

		animSetUp.Setup (speed, angle);
	}

	float FindAngle (Vector3 fromVector, Vector3 toVector, Vector3 upVector) {
		if (toVector == Vector3.zero) {
			return 0f;
		}

		float angle = Vector3.Angle (fromVector, toVector);
		Vector3 normal = Vector3.Cross (fromVector, toVector);
		angle *= Mathf.Sign (Vector3.Dot (normal, upVector));
		angle *= Mathf.Deg2Rad;

		return angle;
	}
}
