using UnityEngine;
using System.Collections;


public class Panel : MonoBehaviour {
	
	[Tooltip ("This contains all objects in the panel")]
	public GameObject[] contains;
	
	private bool working;
	private bool open;
	
	void Start() {
		working = false;
		open = false;
	}
	
	public void CallSlideHorizontal(int amount) {
		if (!working) {
			StartCoroutine(SlideHorizontal(amount));
			working = true;
			open = !open;
		}
	}
	
	public IEnumerator SlideHorizontal(int amount) {
		if (!open) {
			for (int i = 0; i < amount; i++) {
				foreach (GameObject g in contains)
					g.GetComponent<RectTransform>().anchoredPosition = g.GetComponent<RectTransform>().anchoredPosition + new Vector2 (1,0);
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
		else {
			for (int i = 0; i < amount; i++) {
				foreach (GameObject g in contains)
					g.GetComponent<RectTransform>().anchoredPosition = g.GetComponent<RectTransform>().anchoredPosition - new Vector2 (1,0);
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
		working = false;
	}
	
	
	
}
