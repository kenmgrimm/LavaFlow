using System.Collections.Generic;
using UnityEngine;

public class EffectGroup : MonoBehaviour {
  public List<GameObject> effects;
	private int currentIndex = 0;
	
	public void Start() {
		if(effects == null || effects.Count == 0) {
			Debug.LogError("No effects set, aborting");
			gameObject.SetActive(false);
		}
		
		GameObject.Find("Demo Controller").GetComponent<DemoController>().RegisterEffectGroup(this);
	}

	public void OnChangePlay(bool start) {
		Debug.Log("OnChangePlay: " + start);

		CurrentEvent().SetActive(start);
	}
	
	public void OnAdvanceEffect(int count) {
		Debug.Log("OnAdvanceEffect: " + count);
		
		if(!CurrentEvent().activeSelf) {
			return;
		}

		CurrentEvent().SetActive(false);
		
		currentIndex += count;
		
		if (currentIndex < 0) {
			currentIndex = effects.Count - 1;
		}
		else if (currentIndex >= effects.Count) {
			currentIndex = 0;
		}
		
		CurrentEvent().SetActive(true);
	}
	
	private GameObject CurrentEvent() {
		return effects[currentIndex];
	}
}