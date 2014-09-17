using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	//Because the UI Layouts Exist We Will Simply Define Functions Here For Use In the Code
	
	private bool docked = true;
	
	//Functions for buttons
	public void SlideClicked() {
		if (docked)
			StartCoroutine("SlideOut");
		else
			StartCoroutine("SlideIn");
	}
	
	//Internal Functions
	IEnumerator SlideOut() {
		docked = false;
		transform.Find ("Side Panel/Slide Button/Slide Text").GetComponent<Text>().text = "<<";

		for (int i = 0; i<128; i+=3) {
			transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition = transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition + new Vector2(3,0);
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
	
	IEnumerator SlideIn(){
		docked = true;
		transform.Find ("Side Panel/Slide Button/Slide Text").GetComponent<Text>().text = ">>";
		for (int i = 0; i<128; i+=3) {
			transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition = transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition - new Vector2(3,0);
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
