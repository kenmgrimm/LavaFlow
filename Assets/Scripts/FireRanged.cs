using UnityEngine;

public class FireRanged : MonoBehaviour {
	private Animator animator;
	public Transform throat;
	
	public GameObject fireball;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void MouthOpen () {
		Debug.Log("MouthOpen");
	}
	
	void Spit () {
		Debug.Log("Spit");
		Debug.Log(throat.position);
		var effect = Instantiate(fireball, throat);
		effect.transform.localPosition = Vector3.zero;
		effect.transform.rotation = throat.rotation;
		effect.SetActive(true);
		// effect.transform.position = throat.position;	
	}
}
