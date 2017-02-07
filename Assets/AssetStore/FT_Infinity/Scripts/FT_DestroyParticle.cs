﻿using UnityEngine;
using System.Collections;

public class FT_DestroyParticle : MonoBehaviour {

	private float destroyTime = 10.0f;
	private ParticleSystem rootParticle;


	void Start () {		
		rootParticle = transform.FindChild ("root").gameObject.GetComponent<ParticleSystem>();
		destroyTime = rootParticle.duration;
		Destroy(gameObject, destroyTime);	
	}
	

	void Update () {
	
	}
}