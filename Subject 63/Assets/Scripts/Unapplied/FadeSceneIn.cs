using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSceneIn : MonoBehaviour {

	GameObject screenFader;

	void Awake () {
		screenFader = GameObject.FindGameObjectWithTag (Tags.fader);

		screenFader.GetComponent <SceneFaderInOut> ().FadeToClear ();
	}
}
