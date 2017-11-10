using System.Collections;
using UnityEngine;

public class FT_LoopSwitch : MonoBehaviour {
	public float duration = 2f;
	private float timeBetweenPlays = 1f;

	private ParticleSystem particleSystemRoot;

	private float currentTime = 0;

	void Start () {
		particleSystemRoot = transform.Find ("root").gameObject.GetComponent<ParticleSystem>();

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
