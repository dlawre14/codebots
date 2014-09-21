using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextChanger : MonoBehaviour {
	
	//Most of these functions are specific
	
	public void SetSeconds(float seconds) {
		GetComponent<Text>().text = seconds.ToString ("#.##") + " seconds";
	}
	
	public void SetSpeed(float seconds) {
		GetComponent<Text>().text = seconds.ToString ("#.##") + " units/second";
	}
	
	public void SetDegree(float degree) {
		GetComponent<Text>().text = degree + " degree(s)";
	}
	
	public void ChangeText(string text) {
		GetComponent<Text>().text = text;	
	}
}
