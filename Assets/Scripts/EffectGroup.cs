using System.Collections.Generic;
using UnityEngine;

public class EffectGroup : MonoBehaviour {
  public List<GameObject> effects;
  private bool activeGroup = false;
	private int currentIndex = 0;
	private GameObject runningEvent;
	
	public void Start() {
		if(effects == null || effects.Count == 0) {
			Debug.LogError("No effects set, aborting");
			gameObject.SetActive(false);
		}
		
		GameObject.Find("Demo Controller").GetComponent<DemoController>().RegisterEffectGroup(this);
	}

	public void OnChangePlay(bool start) {
		Debug.Log("OnChangePlay: " + start);



		// Todo - this is just to prevent anyone but the active group from acting on UI events :(
		activeGroup = start;
		
		if(runningEvent) {
			runningEvent.SetActive(false);
		}

		if (start) {
			runningEvent = CreateCurrentEvent();
		}
	}
	
	public void OnAdvanceEffect(int count) {
		Debug.Log("OnAdvanceEffect: " + count);
		
		if(!activeGroup) {
			return;
		}

		Destroy(runningEvent);
		
		currentIndex += count;
		
		if (currentIndex < 0) {
			currentIndex = effects.Count - 1;
		}
		else if (currentIndex >= effects.Count) {
			currentIndex = 0;
		}
		
		runningEvent = CreateCurrentEvent();
	}
	
	private GameObject CreateCurrentEvent() {
		var currentEvent = Instantiate(CurrentEvent());
		currentEvent.transform.position = CurrentEvent().transform.position;
		currentEvent.SetActive(true);

		return currentEvent;
	}

	private GameObject CurrentEvent() {
		return effects[currentIndex];
	}
}