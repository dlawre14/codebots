using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextChange : MonoBehaviour {
	
	[Tooltip ("Object containing the UI Text Component")]
	public GameObject obj;
	
	private bool open = false;
	
	public void ChangeText() {
		if (!open) {
			obj.GetComponent<Text>().text = "<<";
			open = true;
		}
		else {
			obj.GetComponent<Text>().text = ">>";
			open = true;
		}
	}	
}
