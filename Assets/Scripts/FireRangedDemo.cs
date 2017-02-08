using System.Collections.Generic;
using UnityEngine;

public class FireRangedDemo : MonoBehaviour {
	[SerializeField]
	private List<GameObject> actions = new List<GameObject>();
	private Animation animation;

	void Start() {
		// animation = gameObject.GetComponent<Animation>();
		// animation.Play("FireRanged_Attack_B");
	}

}
