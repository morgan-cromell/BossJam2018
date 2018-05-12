﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : MonoBehaviour {

    public float force = 10;
    public float damage = 0.1f;
    Resource resource;
    public ParticleSystem particles;
    public LayerMask canAttack;
    bool cooldown = false;
    float cooldownTimer = 0.5f;
    List<int> hitObjects = new List<int>();
    // Use this for initialization
    void Start () {
        resource = GetComponentInParent<Resource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ResetCooldown()
    {
        cooldown = false;
    }
    void StartCooldown()
    {
        cooldown = true;
        Invoke("ResetCooldown", cooldownTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & canAttack) != 0)
        {
            if (!hitObjects.Contains(other.gameObject.layer))
            {
                Resource otherResource = other.gameObject.GetComponentInParent<Resource>();
                if (!otherResource.IsDead())
                {
                    otherResource.RemovePoints(damage, LayerMask.NameToLayer("SweatyCharacter"));
                    resource.AddPoints(damage);
                    hitObjects.Add(other.gameObject.layer);
                }
            }
            other.gameObject.GetComponentInParent<Rigidbody>().AddExplosionForce(force, transform.position, transform.localScale.magnitude);
        }
    }
}
