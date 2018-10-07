using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    GameObject player;
    SceneFaderInOut sceneFadeInOut;
    float timer;
    public float timeToEndLevel = 2f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        sceneFadeInOut = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<SceneFaderInOut>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            timer += Time.deltaTime;
            if (timer >= timeToEndLevel)
                sceneFadeInOut.EndScene();
        }
    }
}
