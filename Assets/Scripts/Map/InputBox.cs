using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputBox : MonoBehaviour {

	private Vector2 pos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPosition(int x, int y) {
		pos = new Vector2 (x, y);
		GetComponentInChildren<Text> ().text = "(" + pos.x + "," + pos.y + ")";
	}
	
	public Vector2 GetPosition() {
		return pos;
	}
	
	public int GetValue() {
		try {
			return System.Convert.ToInt32(GetComponentInChildren<InputField>().value);
		}
		catch (System.FormatException) {
			Debug.LogError("A field contains a non-integer value!");
			return 0;
		}
	} 
}
