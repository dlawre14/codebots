using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugAddr : MonoBehaviour {

	public GameObject panel;

	public InputField length;
	public InputField width;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (10 + System.Convert.ToInt32(length.value) * 10, 10 + System.Convert.ToInt32(width.value) * 10);
	}

	public void AddPanel() {
		GameObject g = (GameObject) Instantiate (panel);
		g.transform.parent = transform;
	}
}
