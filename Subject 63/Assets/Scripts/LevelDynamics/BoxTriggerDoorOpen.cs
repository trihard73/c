using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerDoorOpen : MonoBehaviour {

    bool closed;
    GameObject player;
    Animator anim;
    public AudioSource source;
    public AudioClip doorOpen;
    public GameObject door;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        source = GetComponent<AudioSource>();
        closed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && closed == true) {
            anim.Play("Door Open");
            source.PlayOneShot(doorOpen);
        }
    }
}
