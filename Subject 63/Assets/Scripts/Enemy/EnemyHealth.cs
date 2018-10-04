using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health = 100f;
	public AudioClip deathClip;

	private Animator anim;
	private HashIDs hash;
	private bool enemyDead;
	public EnemyAI enemyMovement;
	public EnemyShooting enemyShooting;
	public EnemySight enemySight;
	//public LastPlayerSighting lastPlayerSighting;


	void Awake () {
		anim = GetComponent<Animator> ();
		//enemyMovement = GameObject.FindGameObjectWithTag (Tags.enemyParent).GetComponent <EnemyAI> ();
		//enemySight = GameObject.FindGameObjectWithTag (Tags.enemyParent).GetComponent <EnemySight> ();
		//enemyShooting = GameObject.FindGameObjectWithTag (Tags.enemyParent).GetComponent <EnemyShooting> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent <HashIDs> ();
		//lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
	}

	void Update () {
		if (health <= 0f) {
			if (!enemyDead) {
				EnemyDying ();
			} else {
				EnemyDead ();
			}
		}
	}

	void EnemyDying () {
		enemyDead = true;
		anim.SetBool (hash.deadBool, true);
		AudioSource.PlayClipAtPoint (deathClip, transform.position);
	}

	void EnemyDead () {
		if (anim.GetCurrentAnimatorStateInfo (0).fullPathHash == hash.dyingState) {
			anim.SetBool (hash.deadBool, false);
		}

		anim.SetFloat (hash.speedFloat, 0f);
		enemyMovement.nav.enabled = false;
		enemyMovement.enabled = false;
		enemySight.enabled = false;
		enemyShooting.enabled = false;
		//lastPlayerSighting.position = lastPlayerSighting.resetPosition; / Turns off Alarm
		GetComponent <AudioSource> ().Stop ();
	}

	public void TakeDamage (float amount) {
		health -= amount;
	}
}
