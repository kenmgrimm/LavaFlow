﻿using System.Collections;
using UnityEngine;

public class LoopEffect : MonoBehaviour {
	private float duration;
	public float timeBetweenPlays = 0.5f;

	private ParticleSystem particleSystemRoot;

	private float currentTime = 0;

	void Start () {
		particleSystemRoot = transform.Find ("root").gameObject.GetComponent<ParticleSystem>();
		duration = particleSystemRoot.main.duration;

		StartCoroutine("Play");
	}
	

	IEnumerator Play() {
		while(true) {
		Debug.Log("LoopEffect.Play(): " + gameObject.name);
			particleSystemRoot.Play(withChildren: true);

			yield return new WaitForSeconds(duration);

			particleSystemRoot.Stop(withChildren: true);

			yield return new WaitForSeconds(timeBetweenPlays);
		}
	}
}
