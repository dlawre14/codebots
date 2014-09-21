using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugToggle : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Toggle>().isOn)
			transform.parent.Find ("Debug Log UI").GetComponent<Text>().enabled =  true;
		else
			transform.parent.Find ("Debug Log UI").GetComponent<Text>().enabled = false;		
	}
}
