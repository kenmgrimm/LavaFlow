using System.Collections;
using UnityEngine;

public class LoopEffect : MonoBehaviour {
	private float duration;
	public float timeBetweenPlays = 0.5f;

	private ParticleSystem particleSystemRoot;

	private float currentTime = 0;

	void Start () {
		particleSystemRoot = transform.FindChild ("root").gameObject.GetComponent<ParticleSystem>();
		duration = particleSystemRoot.main.duration;

		StartCoroutine("Play");
	}
	

	IEnumerator Play() {
		while(true) {
			particleSystemRoot.Play(withChildren: true);

			yield return new WaitForSeconds(duration);

			particleSystemRoot.Stop(withChildren: true);

			yield return new WaitForSeconds(timeBetweenPlays);
		}
	}
}
