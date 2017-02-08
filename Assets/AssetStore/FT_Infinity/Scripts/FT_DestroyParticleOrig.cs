using System.Collections;
using UnityEngine;

public class FT_DestroyParticle : MonoBehaviour {
	private float duration;

	private float timeBeforeStart = 0f;
	private float waitBetweenPlays = 0f;
	public float timeBetweenRounds = 0.5f;

	private ParticleSystem rootParticle;


	void Start () {		
		rootParticle = transform.FindChild ("root").gameObject.GetComponent<ParticleSystem>();
		duration = rootParticle.main.duration;

		timeBeforeStart = this.transform.GetSiblingIndex() * duration;
		waitBetweenPlays = (this.transform.parent.childCount) * duration + timeBetweenRounds;

		Debug.Log(duration + ", " + timeBeforeStart + ", " + waitBetweenPlays);
		rootParticle.gameObject.SetActive(false);

		StartCoroutine("Play");
	}
	
	IEnumerator Play() {
		yield return new WaitForSeconds(timeBeforeStart);

		while(true) {
			rootParticle.gameObject.SetActive(true);
			rootParticle.Play(withChildren: true);

			yield return new WaitForSeconds(waitBetweenPlays);
		}
	}
}
