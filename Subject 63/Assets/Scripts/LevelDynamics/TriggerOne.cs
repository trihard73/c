using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOne : MonoBehaviour {

    GameObject player;
    public AudioClip clip;
    private AudioSource source;
    void Awake()
    {

        source = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            source.PlayOneShot(clip);
        }
    }
}

