using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour {

    public GameObject player;
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
            print("player");
            SceneManager.LoadScene("SampleScene");
            /*if (timer >= timeToEndLevel)
                sceneFadeInOut.EndScene();*/
        }
    }
}
