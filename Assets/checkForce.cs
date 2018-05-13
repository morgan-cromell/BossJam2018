﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForce : MonoBehaviour {

    // Use this for initialization
    public float force = 2.0f;
    public bool play = true;
	void Start () {
        GetComponent<Rigidbody>().AddForce(Vector3.down * force, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        AudioSource AS = gameObject.GetComponent<AudioSource>();
        if (!AS.isPlaying && play)
        {
            AS.Play();
            play = false;
        }
    }
}
