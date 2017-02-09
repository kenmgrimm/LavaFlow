using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour {
  public Button advanceLeft;
  public Button advanceRight;
  
  void Start() {
    if(advanceLeft == null || advanceRight == null) {
      Debug.LogError("Not all elements set in editor, aborting");
      gameObject.SetActive(false);
    }
  }
  
  public void RegisterEffectGroup(EffectGroup effectGroup) {
    advanceLeft.onClick.AddListener(() => effectGroup.OnAdvanceEffect(-1));
    advanceRight.onClick.AddListener(() => effectGroup.OnAdvanceEffect(1));
  }
}
