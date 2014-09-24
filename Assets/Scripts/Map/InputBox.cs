using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputBox : MonoBehaviour {

	private int x = 0;
	private int y = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetPosition(int sx, int sy) {
		x = sx;
		y = sy;

		GetComponentInChildren<Text> ().text = "(" + x + "," + y + ")";
	}
}
