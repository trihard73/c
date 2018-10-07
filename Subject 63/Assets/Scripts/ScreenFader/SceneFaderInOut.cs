using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFaderInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;

	public bool sceneStarting = true;

	Image screenFader;

	void Awake () {
		screenFader = GameObject.FindGameObjectWithTag (Tags.fader).GetComponent<Image> ();
	}

	void Update () {
		if (sceneStarting) {
			StartScene ();
		}
	}

	public void FadeToClear () {
		screenFader.color = Color.Lerp (screenFader.color, Color.clear, fadeSpeed * Time.deltaTime);
		Invoke ("FadeToClear", 1f / 60f);
	}

	public void FadeToBlack () {
		screenFader.color = Color.Lerp (screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
		Invoke ("FadeToBlack", 1f / 60f);
	}

	void StartScene () {
		FadeToClear ();

		if (screenFader.color.a <= 0.05f) {
			screenFader.color = Color.clear;
			screenFader.gameObject.SetActive(false);
			sceneStarting = false;
		}
	}

	public void EndScene () {
		screenFader.gameObject.SetActive(true);
		FadeToBlack ();
		if (screenFader.color.a >= 0.95f) {
			SceneManager.LoadScene ("Subject63");
		}
	}
}
