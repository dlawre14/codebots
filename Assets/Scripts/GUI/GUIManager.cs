using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	//Because the UI Layouts Exist We Will Simply Define Functions Here For Use In the Code
	
	private bool docked = true;
	private Text selected;
	
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

		for (int i = 0; i < transform.Find ("Side Panel/Forward Button").GetComponent<RectTransform>().rect.width; i+=2) {
			transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition = transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition + new Vector2(2,0);
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
	
	IEnumerator SlideIn(){
		docked = true;
		transform.Find ("Side Panel/Slide Button/Slide Text").GetComponent<Text>().text = ">>";
		Debug.Log (transform.Find ("Side Panel/Forward Button").GetComponent<RectTransform> ().rect.width);
		for (int i = 0; i<transform.Find ("Side Panel/Forward Button").GetComponent<RectTransform>().rect.width; i+=2) {
			transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition = transform.Find("Side Panel").GetComponent<RectTransform>().anchoredPosition - new Vector2(2,0);
			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
